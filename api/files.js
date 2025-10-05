import fetch from "node-fetch";

export default async function handler(req, res) {
  const githubApiKey = process.env.VERCEL_GITHUB_API_KEY;
  const owner = process.env.VERCEL_GITHUB_REPO_OWNER;
  const repo = process.env.VERCEL_GITHUB_REPO;
  const branch = process.env.VERCEL_GITHUB_REPO_BRANCH || "main";
  const path = "";

  if (!githubApiKey || !owner || !repo) {
    console.error("Missing environment variables");
    return res.status(500).json({ error: "Missing environment variables" });
  }

  const url = `https://api.github.com/repos/${owner}/${repo}/contents/${path}?ref=${branch}`;
  console.log("Fetching GitHub URL:", url);

  try {
    const response = await fetch(url, {
      headers: {
        Authorization: `token ${githubApiKey}`,
        Accept: "application/vnd.github.v3+json",
      },
    });

    const contentType = response.headers.get("content-type");

    if (!response.ok) {
      const text = await response.text();
      console.error("GitHub API error:", text);
      return res.status(response.status).json({ error: "Failed to fetch from GitHub", details: text });
    }

    if (!contentType || !contentType.includes("application/json")) {
      const text = await response.text();
      console.error("Unexpected response type:", contentType, text);
      return res.status(500).json({ error: "Invalid response from GitHub", details: text });
    }

    const data = await response.json();

    const ignoreFiles = ["index.html", "api"];
    const filteredData = data.filter(item => !ignoreFiles.includes(item.name));

    res.status(200).json(filteredData);
  } catch (error) {
    console.error("Server error:", error);
    res.status(500).json({ error: error.message });
  }
}
