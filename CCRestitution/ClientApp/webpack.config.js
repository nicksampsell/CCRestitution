const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");
const TerserPlugin = require("terser-webpack-plugin");

module.exports = {
	entry: {
		site: './src/js/site.js',
		qrcode: './src/js/qrcode.js',
		actionEditor: './src/js/action-editor-2023-11-16.js',
		rpcEditor: './src/js/rpc-editor-2023-10-05.js',
		rpcHistory: './src/js/rpc-history-2023-09-28.js',
		//jqueryValidate: './src/js/jquery.validate.min.js',
		//jqueryValidateUnobtrusive: './src/js/jquery.validate.unobtrusive.js',
		approvalFlowEditor: './src/js/approvalFlow-2023-11-21.js'
	},
	output: {
		filename: '[name].bundle.js',
		path: path.resolve(__dirname, '..', 'wwwroot', 'dist')
	},
	resolve: {
		alias: {
			'Action-Editor': './src/js/action-editor-2023-11-16.js'
		}
	},
	devtool: 'source-map',
	mode: 'development',
	module: {
		rules: [
			{
				test: /\.css$/,
				use: [{ loader: MiniCssExtractPlugin.loader }, 'css-loader'],

			},
			{
				test: /\.(eot|woff(2)?|ttf|otf|svg)$/i,
				type: 'asset'
			},
		]
	},
	plugins: [
		new MiniCssExtractPlugin({
			filename: "[name].css"
		})
	],
	optimization: {
		minimizer: [
			new CssMinimizerPlugin(),
			new TerserPlugin()
		],
		minimize: false
	}
};