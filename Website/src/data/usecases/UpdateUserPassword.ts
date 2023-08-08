import { InvalidCredentialsError, UnexpectedError } from "../../domain/errors";
import { HttpClient, HttpStatusCode } from "../protocols/http";
import {
  IUpdateUserPassword,
  UpdateUserPasswordRequest,
} from "@/domain/usecases/IUpdateUserPassword";

export class UpdateUserPassword implements IUpdateUserPassword {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<boolean>
  ) {}

  async updatePass(params: UpdateUserPasswordRequest): Promise<boolean> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "patch",
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
