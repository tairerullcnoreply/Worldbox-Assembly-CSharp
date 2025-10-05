import fetch from "node-fetch";

export default async function handler(req, res) {
  const githubApiKey = process.env.VERCEL_GITHUB_API_KEY;
  const owner = process.env.VERCEL_GITHUB_REPO_OWNER;
  const repo = process.env.VERCEL_GITHUB_REPO;
  const branch = process.env.VERCEL_GITHUB_REPO_BRANCH;
  const path = "";

  if (!githubApiKey) {
    return res.status(500).json({ error: "GitHub API key not found" });
  }

  const url = `https://api.github.com/repos/${owner}/${repo}/contents/${path}?ref=${branch}`;

  try {
    const response = await fetch(url, {
      headers: {
        Authorization: `token ${githubApiKey}`,
        Accept: "application/vnd.github.v3+json",
      },
    });

    if (!response.ok) {
      return res.status(response.status).json({ error: "Failed to fetch from GitHub" });
    }

    const data = await response.json();

    // Filter out site files like index.html and API route itself
    const ignoreFiles = ["index.html", "api/files.js"];
    const filteredData = data.filter(
      item => !ignoreFiles.includes(item.name)
    );

    res.status(200).json(filteredData);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
}
