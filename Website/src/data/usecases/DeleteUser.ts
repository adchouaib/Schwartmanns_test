import { HttpClient, HttpStatusCode } from "../protocols/http";
import {
  DeleteUserRequest,
  IDeleteUser,
} from "../../domain/usecases/IDeleteUser";
import { InvalidCredentialsError } from "../../domain/errors/InvalidCredentialsError";
import { UnexpectedError } from "../../domain/errors";

export class DeleteUser implements IDeleteUser {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<DeleteUserRequest>
  ) {}

  async delete(params: DeleteUserRequest): Promise<boolean> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "delete",
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
