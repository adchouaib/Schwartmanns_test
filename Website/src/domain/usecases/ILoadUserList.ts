import { User } from "../models/User";

export interface ILoadUserList {
  loadAll: () => Promise<User[]>;
}
