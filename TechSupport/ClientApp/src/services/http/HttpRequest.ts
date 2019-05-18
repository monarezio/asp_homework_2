import axios from 'axios';
import qs from 'qs';
import HttpRequestType from "./HttpRequestType";
import {api_settings} from "../../constants";

let instance: HttpRequest | null = null;

class HttpRequest {

    constructor() {
        if (instance === null)
            instance = this;

        return instance;
    }

    send<T>(url: string, method_type: HttpRequestType, body: Object, query: Object) {
        return axios.request<T>({
            baseURL: api_settings.getUrl(),
            url: url,
            method: method_type,
            withCredentials: true,
            data: body,
            params: query,
        });
    }

    sendGet<T>(url: string, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.get, {}, query);
    }

    sendPost<T>(url: string, body: Object = {}) {
        return this.send<T>(url, HttpRequestType.post, body, {});
    }

    sendDelete<T>(url: string, body: Object = {}, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.delete, body, query);
    }

    sendPut<T>(url: string, body: Object = {}, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.put, body, query);
    }
}

export default HttpRequest;