import { LoadDashboardTotal } from "../../../data/usecases";
import { ILoadDashboardTotal } from "@/domain/usecases";
import { makeAuthorizeClientAdapter } from "../adapters";
import { makeApiUrl } from "../http";

export const makeLoadDashboardTotal = (): ILoadDashboardTotal =>
  new LoadDashboardTotal(
    makeApiUrl("/dashboard/getTotal"),
    makeAuthorizeClientAdapter()
  );
