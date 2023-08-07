import { LoadUserList } from "../../../data/usecases/LoadUserList";
import { ILoadUserList } from "../../../domain/usecases/ILoadUserList";
import { makeAuthorizeClientAdapter } from "../adapters/authorizedClientAdapter";
import { makeApiUrl } from "../http/ApiUrlFactory";

export const makeLoadUserList = (): ILoadUserList =>
  new LoadUserList(makeApiUrl("/user/all"), makeAuthorizeClientAdapter());
