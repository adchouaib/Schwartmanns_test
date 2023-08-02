// BUG: import should be @/presentation/pages
import WeatherList from "../../../presentation/pages/WeatherList/WeatherList";
import React from "react";
import { makeLoadWeatherList } from "../usecases";

export const makeWeatherPage: React.FC = () => {
  return <WeatherList loadWeatherList={makeLoadWeatherList()} />;
};
