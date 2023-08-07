// BUG: import again
import { LoadWeatherList } from "../../../data/usecases";
import { ILoadWeatherList } from "@/domain/usecases";
import { makeApiUrl, makeAxiosHttpClient } from "../http";

export const makeLoadWeatherList = (): ILoadWeatherList =>
  new LoadWeatherList(makeApiUrl("/WeatherForecast"), makeAxiosHttpClient());
