import { UnexpectedError } from "../../domain/errors";
import { InvalidCredentialsError } from "../../domain/errors/InvalidCredentialsError";
import {
  CreateUserRequest,
  ICreateUser,
} from "../../domain/usecases/ICreateUser";
import { HttpClient, HttpStatusCode } from "../protocols/http";

export class CreateUser implements ICreateUser {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<CreateUserRequest>
  ) {}

  async create(params: CreateUserRequest): Promise<boolean> {
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
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
