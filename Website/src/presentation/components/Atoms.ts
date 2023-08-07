import { getCurrentAccount } from "../../main/adapters";
import { Account } from "@/domain/models";
import { atom } from "recoil";

export const AccountState = atom<Account | null>({
  key: "Account",
  default: getCurrentAccount(),
});
