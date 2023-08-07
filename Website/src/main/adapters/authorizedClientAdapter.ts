import { GetStorage } from "../../data/protocols/cache/getStorage";
import {
  HttpClient,
  HttpRequest,
  HttpResponse,
} from "../../data/protocols/http";

export class AuthorizedClientAdapter implements HttpClient {
  constructor(
    private readonly getStorage: GetStorage,
    private readonly httpClient: HttpClient
  ) {}

  async request(data: HttpRequest): Promise<HttpResponse> {
    const account = this.getStorage.get("account");

    if (account?.token) {
      const modifiedHeaders = {
        ...(data.headers || {}),
        Authorization: `Bearer ${account.token}`,
      };

      const modifiedData = { ...data, headers: modifiedHeaders };
      const httpResponse = await this.httpClient.request(modifiedData);
      return httpResponse;
    } else {
      const httpResponse = await this.httpClient.request(data);
      return httpResponse;
    }
  }
}
