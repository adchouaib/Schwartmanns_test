import { HttpClient, HttpStatusCode } from "../protocols/http";
import { User } from "@/domain/models/User";
import { AccessDeniedError, UnexpectedError } from "../../domain/errors";
import { ILoadUserList } from "@/domain/usecases/ILoadUserList";

export class LoadUserList implements ILoadUserList {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<User[]>
  ) {}
  async loadAll(): Promise<User[]> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "get",
    });

    const UserList = HttpResponse.body || [];

    switch (HttpResponse.statusCode) {
      case HttpStatusCode.ok:
        return UserList.map((user) => ({ ...user }));
      case HttpStatusCode.noContent:
        return [];
      case HttpStatusCode.forbidden:
        throw new AccessDeniedError();
      default:
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
