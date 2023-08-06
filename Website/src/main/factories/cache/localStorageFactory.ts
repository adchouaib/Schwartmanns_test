import { LocalStorage } from "../../../infrastructure/cache/localStorage";

export const makeLocalStorage = (): LocalStorage => new LocalStorage();
