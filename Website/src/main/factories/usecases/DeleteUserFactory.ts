import { DeleteUser } from "../../../data/usecases/DeleteUser";
import { IDeleteUser } from "../../../domain/usecases/IDeleteUser";
import { makeApiUrl } from "../http";
import { makeAuthorizeClientAdapter } from "../adapters/authorizedClientAdapter";

export const makeDeleteUser = (): IDeleteUser =>
  new DeleteUser(makeApiUrl(`/user/delete`), makeAuthorizeClientAdapter());
