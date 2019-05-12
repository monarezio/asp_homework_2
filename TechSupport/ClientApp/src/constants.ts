export const api_settings = {
    protocol: "https",
    domain: window.location.href.split('/')[2],
    path: "/api",
    version: "",

    getUrl: function() {
        return `${this.protocol}://${this.domain}${this.path}/${this.version}`
    },
};