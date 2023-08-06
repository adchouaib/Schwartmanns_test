/* eslint-disable @typescript-eslint/no-explicit-any */
import { GetStorage } from "../../data/protocols/cache/getStorage";
import { SetStorage } from "../../data/protocols/cache/setStorage";

export class LocalStorage implements SetStorage, GetStorage {
  set(key: string, value: object): void {
    if (value) {
      localStorage.setItem(key, JSON.stringify(value));
    } else {
      localStorage.removeItem(key);
    }
  }

  get(key: string): any {
    const item = localStorage.getItem(key);
    return item !== null ? JSON.parse(item) : null;
  }
}
