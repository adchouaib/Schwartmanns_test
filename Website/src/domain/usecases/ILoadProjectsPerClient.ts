import { ProjectPerClient } from "../models";

export interface ILoadProjectsPerClient {
  loadAll: () => Promise<ProjectPerClient[]>;
}
