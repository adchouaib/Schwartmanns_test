import { LoadUserList } from "../../../data/usecases/LoadUserList";
import { ILoadUserList } from "../../../domain/usecases/ILoadUserList";
import { makeApiUrl } from "../http/ApiUrlFactory";
import { makeAxiosHttpClient } from "../http/AxiosHttpClientFactory";

export const makeLoadUserList = (): ILoadUserList =>
  new LoadUserList(makeApiUrl("/user/all"), makeAxiosHttpClient());
