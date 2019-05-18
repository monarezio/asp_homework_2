module.exports = ({ options }) => {
    const plugins = [
        require('autoprefixer')({
            'browsers': ['> 1%', 'last 2 versions']
        })
    ];
    if (options.env === 'production') plugins.push(require('cssnano'));
    return {
        plugins: plugins
    };
};