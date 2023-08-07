import { CreateUser } from "../../../data/usecases";
import { ICreateUser } from "@/domain/usecases";
import { makeAuthorizeClientAdapter } from "../adapters";
import { makeApiUrl } from "../http";

export const makeCreateUser = (): ICreateUser =>
  new CreateUser(makeApiUrl("/user/create"), makeAuthorizeClientAdapter());
