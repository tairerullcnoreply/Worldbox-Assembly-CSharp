import path from "path";
import { promises as fs } from "fs";

const ROOT_DIR = process.cwd();
const PREVIEW_LIMIT = 8000;
const HIDDEN_TOP_LEVEL = new Set(["api", "__vc"]);

function normalisePath(requestedPath = "") {
  const sanitised = requestedPath.replace(/\\/g, "/");
  const normalised = path.posix.normalize(sanitised).replace(/^\.(\/|$)/, "");
  return normalised === "." ? "" : normalised;
}

function resolvePath(requestedPath = "") {
  const normalised = normalisePath(requestedPath);
  const resolved = path.resolve(ROOT_DIR, normalised);

  if (!resolved.startsWith(ROOT_DIR)) {
    const error = new Error("Path is outside of the project directory");
    error.statusCode = 400;
    throw error;
  }

  return { resolved, normalised };
}

async function describeEntry(dirent, basePath, directoryPath) {
  const joined = basePath ? path.posix.join(basePath, dirent.name) : dirent.name;
  const entry = {
    name: dirent.name,
    path: joined,
    type: dirent.isDirectory() ? "directory" : "file",
  };

  if (!dirent.isDirectory()) {
    try {
      const fileStats = await fs.stat(path.join(directoryPath, dirent.name));
      entry.size = fileStats.size;
    } catch (error) {
      console.warn(`Unable to stat file ${dirent.name}`, error);
    }
  }

  return entry;
}

function isLikelyText(buffer) {
  const sample = buffer.subarray(0, Math.min(buffer.length, 8000));
  return !sample.includes(0);
}

export default async function handler(req, res) {
  if (req.method !== "GET") {
    res.setHeader("Allow", "GET");
    return res.status(405).json({ error: "Method not allowed" });
  }

  try {
    const { path: requestedPath = "", format = "json" } = req.query ?? {};
    const decodedPath = Array.isArray(requestedPath) ? requestedPath.join("/") : requestedPath;
    const decodedFormat = Array.isArray(format) ? format[0] : format;

    const { resolved, normalised } = resolvePath(decodeURIComponent(decodedPath));
    const stats = await fs.stat(resolved);

    res.setHeader("Cache-Control", "no-store");
    res.setHeader("X-Content-Type-Options", "nosniff");

    if (stats.isDirectory()) {
      const entries = await fs.readdir(resolved, { withFileTypes: true });
      const visibleEntriesPromises = entries
        .filter(entry => !entry.name.startsWith("."))
        .filter(entry => normalised !== "" || !HIDDEN_TOP_LEVEL.has(entry.name))
        .map(entry => describeEntry(entry, normalised, resolved));
      const visibleEntries = await Promise.all(visibleEntriesPromises);

      const parent = normalised ? path.posix.dirname(normalised) : null;
      const safeParent = parent === "." ? "" : parent;

      const directoryPayload = {
        type: "directory",
        path: normalised,
        parent: normalised ? safeParent : null,
        entries: visibleEntries.sort((a, b) => {
          if (a.type === b.type) {
            return a.name.localeCompare(b.name, undefined, { sensitivity: "base" });
          }
          return a.type === "directory" ? -1 : 1;
        }),
      };

      res.setHeader("Content-Type", "application/json; charset=utf-8");
      return res.status(200).json(directoryPayload);
    }

    if (decodedFormat === "raw") {
      const buffer = await fs.readFile(resolved);
      const binary = !isLikelyText(buffer);
      res.setHeader("Content-Type", binary ? "application/octet-stream" : "text/plain; charset=utf-8");
      return res.status(200).send(buffer);
    }

    const fileBuffer = await fs.readFile(resolved);
    const textFriendly = isLikelyText(fileBuffer);
    let preview = null;
    let truncated = false;

    if (textFriendly) {
      preview = fileBuffer.toString("utf8");
      if (preview.length > PREVIEW_LIMIT) {
        preview = `${preview.slice(0, PREVIEW_LIMIT)}\n…\n[preview truncated at ${PREVIEW_LIMIT} characters]`;
        truncated = true;
      }
    }

    const filePayload = {
      type: "file",
      path: normalised,
      name: path.basename(normalised),
      size: stats.size,
      encoding: textFriendly ? "utf-8" : "binary",
      preview,
      truncated,
      rawUrl: `/api/files?path=${encodeURIComponent(normalised)}&format=raw`,
    };

    res.setHeader("Content-Type", "application/json; charset=utf-8");
    return res.status(200).json(filePayload);
  } catch (error) {
    console.error("API error while reading files", error);
    const statusCode = error.statusCode ?? (error.code === "ENOENT" ? 404 : 500);
    const message = statusCode === 404 ? "Path not found" : error.message || "Unexpected error";
    res.setHeader("Content-Type", "application/json; charset=utf-8");
    return res.status(statusCode).json({ error: message });
  }
}
