import { Account } from "../../domain/models/Account";
import { makeLocalStorage } from "../factories/cache/localStorageFactory";

export const setCurrentAccount = (account: Account): void => {
  makeLocalStorage().set("account", account);
};

export const getCurrentAccount = (): Account => {
  return makeLocalStorage().get("account");
};
