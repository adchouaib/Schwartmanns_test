import { Account } from "../models/Account";

export interface IAuthenticate {
  auth: (params: AuthenticationRequest) => Promise<Account>;
}

export type AuthenticationRequest = {
  email: string;
  password: string;
};
