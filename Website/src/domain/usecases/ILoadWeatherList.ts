import { Weather } from "@/domain/models/WeatherList";

export interface ILoadWeatherList {
  loadAll: () => Promise<Weather[]>;
}
