import { InvalidCredentialsError, UnexpectedError } from "../../domain/errors";
import { CreateUserRequest, ICreateUser } from "@/domain/usecases/ICreateUser";
import { HttpClient, HttpStatusCode } from "../protocols/http";

export class CreateUser implements ICreateUser {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<boolean>
  ) {}

  async create(params: CreateUserRequest): Promise<boolean> {
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
