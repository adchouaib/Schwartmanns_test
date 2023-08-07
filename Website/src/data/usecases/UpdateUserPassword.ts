import { HttpClient, HttpStatusCode } from "../protocols/http";

import { InvalidCredentialsError } from "../../domain/errors/InvalidCredentialsError";
import { UnexpectedError } from "../../domain/errors";
import {
  IUpdateUserPassword,
  UpdateUserPasswordRequest,
} from "../../domain/usecases/IUpdateUserPassword";

export class UpdateUserPassword implements IUpdateUserPassword {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<UpdateUserPasswordRequest>
  ) {}

  async updatePass(params: UpdateUserPasswordRequest): Promise<boolean> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "patch",
      body: params,
    });

    switch (HttpResponse.statusCode) {
      case HttpStatusCode.ok:
        return HttpResponse.body;
      case HttpStatusCode.unauthorized:
        throw new InvalidCredentialsError();
      default:
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
