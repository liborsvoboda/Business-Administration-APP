// Combined 'require' statements
const path = require('path');
const nodeExternals = require('webpack-node-externals');
const webpack = require('webpack');
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');

const frontConfig = {
   
        watch: true,
        //mode: "production",
        entry: { 'main': './scripts/main.js' }
    ,
        //devServer: {
        //    quiet: true,
        //    historyApiFallback: true,
        //    https: true,
        //    hot: true,
        //    host: '0.0.0.0',  //allow all hosts
        //    compress: true,
        //    proxyTable: {
        //        '/contactlists': {
        //                 headers: {
        //                        'Authorization': 'Basic bGlib3Iuc3ZvYm9kYUBrbGlrbmV0ZXpkZS5jejo4a2FsM3hpanIwNnF1bjMybnd3eXVicG04bjN4Z2FkM2s2M25iNmk2'
        //                            },
        //            "target": 'https://app.smartemailing.cz/api/v3/contactlists',
        //            //"pathRewrite": { '^/contactlists': 'neco' },
        //            "changeOrigin": true,
        //            secure: false

        //        }
        //    }
        //},
        //node: { fs: 'empty', net: 'empty' },
        output: {
            path: path.resolve(__dirname, "wwwroot/dist"),
            filename: "bundle.js",
            publicPath: 'dist/',
            hotUpdateChunkFilename: 'hot/hot-update.js',
            hotUpdateMainFilename: 'hot/hot-update.json'
        },
        optimization: {
            minimize: true
        },
        performance: {
            hints: false
        },
        module: {
            rules: [
                {
                    test: /\.css$/,
                    //use: [{ loader: "style-loader" }, { loader: "css-loader" }, { loader: "vue-style-loader" }]
                    use: ['vue-style-loader', 'css-loader']
                },
                {
                    test: /\.scss$/,
                    use: ExtractTextPlugin.extract({
                        fallback: "style-loader",
                        use: [{ loader: "css-loader"/*, options: { minimize: true }*/ }, { loader: "sass-loader" }]
                    })
                },
                {
                    test: /\.js$/,
                    exclude: /node_modules/,
                    use: {
                        loader: "babel-loader"
                    }
                },
                {
                    test: /\.vue$/,
                    use: 'vue-loader'
                },
                {
                    resourceQuery: /blockType=i18n/,
                    type: 'javascript/auto',
                    loader: '@kazupon/vue-i18n-loader',
                },
                {
                    test: /\.jst$/,
                    use: 'raw-loader'
                }
            ]
        },
        plugins: [
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery",
                "window.jQuery": "jquery",
                Popper: ["popper.js", "default"]
            }),
            new ExtractTextPlugin("site.css"),
            new VueLoaderPlugin()

        ]

   

}
const backConfig = {

        watch: true,
        //mode: "production",

        target: "node",
        entry: {
            'main': "./scripts/backend/backend.js"
        },
        output: {
            path: path.resolve(__dirname, "wwwroot/dist"),
            filename: "bundle-back.js",
            publicPath: 'dist/'
        },
        externals: [nodeExternals()],
   
}
// Combined 'module.exports'
module.exports = [frontConfig, backConfig];