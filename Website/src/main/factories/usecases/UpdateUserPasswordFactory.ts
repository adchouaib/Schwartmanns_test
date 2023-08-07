import { UpdateUserPassword } from "../../../data/usecases";
import { IUpdateUserPassword } from "@/domain/usecases";
import { makeApiUrl } from "../http";
import { makeAuthorizeClientAdapter } from "../adapters";

export const makeUpdateUserPassword = (): IUpdateUserPassword =>
  new UpdateUserPassword(
    makeApiUrl("/user/updatePassword"),
    makeAuthorizeClientAdapter()
  );
