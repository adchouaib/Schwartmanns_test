// BUG: import should be @/presentation/pages

import React from "react";
import { makeLoadWeatherList } from "../usecases";
import { WeatherList } from "../../../presentation/pages";

export const makeWeatherPage: React.FC = () => {
  return <WeatherList loadWeatherList={makeLoadWeatherList()} />;
};
