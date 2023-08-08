import { LoadProjectsPerClient } from "../../../data/usecases";
import { ILoadProjectsPerClient } from "@/domain/usecases";
import { makeAuthorizeClientAdapter } from "../adapters";
import { makeApiUrl } from "../http";

export const makeLoadProjectsPerClient = (): ILoadProjectsPerClient =>
  new LoadProjectsPerClient(
    makeApiUrl("/dashboard/getProjectPerClient"),
    makeAuthorizeClientAdapter()
  );
