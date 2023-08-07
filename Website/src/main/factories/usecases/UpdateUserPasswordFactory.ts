import { UpdateUserPassword } from "../../../data/usecases/UpdateUserPassword";
import { IUpdateUserPassword } from "../../../domain/usecases/IUpdateUserPassword";
import { makeApiUrl } from "../http";
import { makeAuthorizeClientAdapter } from "../adapters/authorizedClientAdapter";

export const makeUpdateUserPassword = (): IUpdateUserPassword =>
  new UpdateUserPassword(
    makeApiUrl("/user/updatePassword"),
    makeAuthorizeClientAdapter()
  );
