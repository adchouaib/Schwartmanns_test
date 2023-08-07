import { HttpClient } from "@/data/protocols/http";
import { AuthorizedClientAdapter } from "../../../main/adapters";
import { makeLocalStorage } from "../cache";
import { makeAxiosHttpClient } from "../http";

export const makeAuthorizeClientAdapter = (): HttpClient =>
  new AuthorizedClientAdapter(makeLocalStorage(), makeAxiosHttpClient());
