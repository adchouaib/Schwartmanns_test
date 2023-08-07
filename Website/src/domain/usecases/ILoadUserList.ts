import { User } from "@/domain/models/User";

export interface ILoadUserList {
  loadAll: () => Promise<User[]>;
}
