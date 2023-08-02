// BUG: import again
import { LoadWeatherList } from "../../../data/usecases";
import { ILoadWeatherList } from "../../../domain/usecases";
import { makeApiUrl } from "../http/ApiUrlFactory";
import { makeAxiosHttpClient } from "../http/AxiosHttpClientFactory";

export const makeLoadWeatherList = (): ILoadWeatherList =>
  new LoadWeatherList(makeApiUrl("/WeatherForecast"), makeAxiosHttpClient());
