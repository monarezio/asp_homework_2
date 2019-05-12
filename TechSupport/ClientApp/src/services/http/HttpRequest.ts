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

    send<T>(url: string, method_type: HttpRequestType, body: Object, query: Object, headers: Object = {}) {
        return axios.request<T>({
            baseURL: api_settings.getUrl(),
            url: url,
            method: method_type,
            withCredentials: true,
            data: qs.stringify(body),
            params: query,
            headers: headers
        });
    }

    sendGet<T>(url: string, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.get, {}, query);
    }

    sendPost<T>(url: string, body: Object = {}, is_multipart: Boolean = false) {
        if (!is_multipart)
            return this.send<T>(url, HttpRequestType.post, body, {});
        else
            return this.send<T>(url, HttpRequestType.post, body, {}, {
                'Content-Type': 'multipart/form-data'
            });
    }

    sendDelete<T>(url: string, body: Object = {}, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.delete, body, query);
    }

    sendPut<T>(url: string, body: Object = {}, query: Object = {}) {
        return this.send<T>(url, HttpRequestType.put, body, query);
    }
}

export default HttpRequest;