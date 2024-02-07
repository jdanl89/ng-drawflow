const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/nodes"
    ],
    target: "https://localhost:7268",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
