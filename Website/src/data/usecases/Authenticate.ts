import { Account } from "../../domain/models/Account";
import {
  AuthenticationRequest,
  IAuthenticate,
} from "../../domain/usecases/IAuthenticate";
import { HttpClient, HttpStatusCode } from "../protocols/http";
import { InvalidCredentialsError } from "../../domain/errors/InvalidCredentialsError";
import { UnexpectedError } from "../../domain/errors";

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
        return HttpResponse.body;
      case HttpStatusCode.unauthorized:
        throw new InvalidCredentialsError();
      default:
        throw new UnexpectedError();
    }
  }
}
