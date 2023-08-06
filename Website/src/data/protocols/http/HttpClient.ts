/* eslint-disable @typescript-eslint/no-explicit-any */
export type HttpMethod = "post" | "get" | "put" | "delete";

export enum HttpStatusCode {
  ok = 200,
  created = 201,
  noContent = 204,
  badRequest = 400,
  unauthorized = 401,
  forbidden = 403,
  notFound = 404,
  serverError = 500,
}

export type HttpRequest = {
  url: string;
  method: HttpMethod;
  body?: any;
  headers?: any;
};

export type HttpResponse<T = any> = {
  statusCode: HttpStatusCode;
  body?: T;
  error: string;
};

export interface HttpClient<T = any> {
  request: (data: HttpRequest) => Promise<HttpResponse<T>>;
}
