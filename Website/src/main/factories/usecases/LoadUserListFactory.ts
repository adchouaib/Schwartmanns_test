import { LoadUserList } from "../../../data/usecases";
import { ILoadUserList } from "@/domain/usecases";
import { makeAuthorizeClientAdapter } from "../adapters";
import { makeApiUrl } from "../http";

export const makeLoadUserList = (): ILoadUserList =>
  new LoadUserList(makeApiUrl("/user/all"), makeAuthorizeClientAdapter());
