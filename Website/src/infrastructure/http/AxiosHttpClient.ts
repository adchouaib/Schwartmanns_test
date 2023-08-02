/* eslint-disable @typescript-eslint/no-explicit-any */
import {
  HttpClient,
  HttpRequest,
  HttpResponse,
} from "../../data/protocols/http";
import axios, { AxiosResponse } from "axios";

export class AxiosHttpClient implements HttpClient {
  async request(data: HttpRequest): Promise<HttpResponse> {
    let response: AxiosResponse;

    try {
      response = await axios.request({
        url: data.url,
        method: data.method,
        data: data.body,
        headers: data.headers,
      });
    } catch (error: any) {
      response = error.response;
    }
    return {
      statusCode: response.status,
      body: response.data,
    };
  }
}
