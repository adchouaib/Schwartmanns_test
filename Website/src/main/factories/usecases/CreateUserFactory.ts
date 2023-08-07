import { CreateUser } from "../../../data/usecases/CreateUser";
import { ICreateUser } from "../../../domain/usecases/ICreateUser";
import { makeAuthorizeClientAdapter } from "../adapters/authorizedClientAdapter";
import { makeApiUrl } from "../http";

export const makeCreateUser = (): ICreateUser =>
  new CreateUser(makeApiUrl("/user/create"), makeAuthorizeClientAdapter());
