import { Stat } from "../models";

export interface ILoadDashboardTotal {
  loadAll: () => Promise<Stat[]>;
}
