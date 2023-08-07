import { LocalStorage } from "../../../infrastructure/cache";

export const makeLocalStorage = (): LocalStorage => new LocalStorage();
