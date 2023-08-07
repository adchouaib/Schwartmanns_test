import { ILoadDashboardTotal } from "@/domain/usecases";
import { HttpClient, HttpStatusCode } from "../protocols/http";
import { Stat } from "@/domain/models";
import { AccessDeniedError, UnexpectedError } from "../../domain/errors";

export class LoadDashboardTotal implements ILoadDashboardTotal {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<Stat[]>
  ) {}
  async loadAll(): Promise<Stat[]> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "get",
    });

    const WeatherList = HttpResponse.body || [];

    switch (HttpResponse.statusCode) {
      case HttpStatusCode.ok:
        return WeatherList.map((weather) => ({ ...weather }));
      case HttpStatusCode.noContent:
        return [];
      case HttpStatusCode.forbidden:
        throw new AccessDeniedError();
      default:
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
