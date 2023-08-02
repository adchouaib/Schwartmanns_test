import { Weather } from "../models/WeatherList";

export interface ILoadWeatherList {
  loadAll: () => Promise<Weather[]>;
}
