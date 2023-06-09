﻿const path = require('path');
const nodeExternals = require('webpack-node-externals');

module.exports = {
    target: "node",
    entry: {
        app: ["./scripts/backend/backend.js"]
    },
    output: {
        path: path.resolve(__dirname, "../build"),
        filename: "bundle-back.js"
    },
    externals: [nodeExternals()],
};