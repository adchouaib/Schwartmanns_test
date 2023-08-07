import { Account } from "@/domain/models/Account";
import { makeLocalStorage } from "../factories/cache";
import jwtDecode from "jwt-decode";

export const setCurrentAccount = (account: Account): void => {
  makeLocalStorage().set("account", account);
};

export const getCurrentAccount = (): Account => {
  return makeLocalStorage().get("account");
};

export const removeCurrentAccount = (): void => {
  return makeLocalStorage().remove("account");
};

export const isTokenExpired = (): boolean => {
  const token = getCurrentAccount()?.token;
  if (token) {
    const decodeToken = jwtDecode<{ exp: number }>(token);
    if (decodeToken.exp && Date.now() >= decodeToken.exp * 1000) {
      return true;
    }
  }
  return false;
};
