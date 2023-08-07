import { HttpClient } from "../../../data/protocols/http";
import { AuthorizedClientAdapter } from "../../../main/adapters/authorizedClientAdapter";
import { makeLocalStorage } from "../cache/localStorageFactory";
import { makeAxiosHttpClient } from "../http";

export const makeAuthorizeClientAdapter = (): HttpClient =>
  new AuthorizedClientAdapter(makeLocalStorage(), makeAxiosHttpClient());
