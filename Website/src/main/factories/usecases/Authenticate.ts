import { Authenticate } from "../../../data/usecases";
import { IAuthenticate } from "@/domain/usecases";
import { makeApiUrl, makeAxiosHttpClient } from "../http";

export const makeAuthentication = (): IAuthenticate =>
  new Authenticate(makeApiUrl("/user/login"), makeAxiosHttpClient());
