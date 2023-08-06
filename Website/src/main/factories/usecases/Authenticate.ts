import { Authenticate } from "../../../data/usecases/Authenticate";
import { IAuthenticate } from "../../../domain/usecases/IAuthenticate";
import { makeApiUrl, makeAxiosHttpClient } from "../http";

export const makeAuthentication = (): IAuthenticate =>
  new Authenticate(makeApiUrl("/user/login"), makeAxiosHttpClient());
