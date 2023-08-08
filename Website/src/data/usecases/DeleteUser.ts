import { HttpClient, HttpStatusCode } from "../protocols/http";
import { DeleteUserRequest, IDeleteUser } from "@/domain/usecases/IDeleteUser";
import { InvalidCredentialsError, UnexpectedError } from "../../domain/errors";

export class DeleteUser implements IDeleteUser {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<boolean>
  ) {}

  async delete(params: DeleteUserRequest): Promise<boolean> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "delete",
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
