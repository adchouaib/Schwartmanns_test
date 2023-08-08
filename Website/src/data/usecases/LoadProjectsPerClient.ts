import { ILoadProjectsPerClient } from "@/domain/usecases";
import { HttpClient, HttpStatusCode } from "../protocols/http";
import { ProjectPerClient } from "@/domain/models";
import { AccessDeniedError, UnexpectedError } from "../../domain/errors";

export class LoadProjectsPerClient implements ILoadProjectsPerClient {
  constructor(
    private readonly url: string,
    private readonly httpClient: HttpClient<ProjectPerClient[]>
  ) {}
  async loadAll(): Promise<ProjectPerClient[]> {
    const HttpResponse = await this.httpClient.request({
      url: this.url,
      method: "get",
    });

    const Projects = HttpResponse.body || [];

    switch (HttpResponse.statusCode) {
      case HttpStatusCode.ok:
        return Projects.map((project) => ({ ...project }));
      case HttpStatusCode.noContent:
        return [];
      case HttpStatusCode.forbidden:
        throw new AccessDeniedError();
      default:
        throw new UnexpectedError(HttpResponse.error);
    }
  }
}
