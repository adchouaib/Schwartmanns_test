import { InvalidCredentialsError, UnexpectedError } from "../../domain/errors";
import {
  AuthenticationRequest,
  IAuthenticate,
} from "@/domain/usecases/IAuthenticate";
import { HttpClient, HttpStatusCode } from "../protocols/http";

import { Account } from "@/domain/models";

export class Authenticate implements IAuthenticate {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<Account>
  ) {}

  async auth(params: AuthenticationRequest): Promise<Account> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "post",
      body: params,
    });

    switch (HttpResponse.statusCode) {
      case HttpStatusCode.ok:
        if (HttpResponse.body) {
          return HttpResponse.body;
        } else {
          throw new UnexpectedError("Response body is missing");
        }
      case HttpStatusCode.unauthorized:
        throw new InvalidCredentialsError();
      default:
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
