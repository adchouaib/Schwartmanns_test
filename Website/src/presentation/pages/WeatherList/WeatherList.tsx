import { Weather } from "@/domain/models";
import { ILoadWeatherList } from "@/domain/usecases";
import React, { useEffect, useState } from "react";
import WeatherCard from "./Components/WeatherCard";
import { Grid, Typography } from "@mui/material";

type Props = {
  loadWeatherList: ILoadWeatherList;
};

const WeatherList: React.FC<Props> = ({ loadWeatherList }: Props) => {
  const [weather, setWeather] = useState<Weather[]>([]);

  useEffect(() => {
    console.log("making request" + import.meta.env.VITE_API_URL);
    loadWeatherList.loadAll().then((res) => setWeather(res));
  }, [loadWeatherList]);

  return (
    <>
      <Typography
        variant="h1"
        component="h1"
        align="center"
        noWrap
        sx={{
          fontFamily: "Big Shoulders Display, cursive",
        }}
      >
        Weather API
      </Typography>
      <Typography
        variant="h6"
        component="h6"
        align="center"
        color={"GrayText"}
        sx={{
          fontFamily: "Lexend Deca, sans-serif",
        }}
      >
        made using Dotnet and ReactJs
      </Typography>
      <Grid
        marginTop={10}
        container
        direction="row"
        justifyContent="center"
        alignItems="center"
        gap={2}
      >
        {weather.map((w, i) => (
          <WeatherCard key={i} weather={w} />
        ))}
      </Grid>
    </>
  );
};

export default WeatherList;
