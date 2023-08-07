import { DeleteUser } from "../../../data/usecases";
import { IDeleteUser } from "@/domain/usecases";
import { makeApiUrl } from "../http";
import { makeAuthorizeClientAdapter } from "../adapters";

export const makeDeleteUser = (): IDeleteUser =>
  new DeleteUser(makeApiUrl(`/user/delete`), makeAuthorizeClientAdapter());
