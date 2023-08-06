import { getCurrentAccount } from "../../main/adapters/currentAccountAdapter";
import { Account } from "../../domain/models/Account";
import { atom } from "recoil";

export const AccountState = atom<Account | null>({
  key: "Account",
  default: getCurrentAccount(),
});
