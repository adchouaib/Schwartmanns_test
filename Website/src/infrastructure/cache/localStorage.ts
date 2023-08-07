/* eslint-disable @typescript-eslint/no-explicit-any */
import { GetStorage, RemoveStorage, SetStorage } from "@/data/protocols/cache";

export class LocalStorage implements SetStorage, GetStorage, RemoveStorage {
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

  remove(key: string): void {
    localStorage.removeItem(key);
  }
}
