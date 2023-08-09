import { Weather } from "@/domain/models";
import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import CardMedia from "@mui/material/CardMedia";
import SunIcon from "../../../../assets/suncon.png";
import WindyIcon from "../../../../assets/windycon.png";
import WindyCloudIcon from "../../../../assets/windycloudycon.png";
import SnowIcon from "../../../../assets/snowcon.png";
import PartyCloudIcon from "../../../../assets/partlycloudycon.png";
import CloudIcon from "../../../../assets/cloudycon.png";
import LightrainIcon from "../../../../assets/lightraincon.png";
import LightningIcon from "../../../../assets/lightningcon.png";
import HeavyrainIcon from "../../../../assets/heavyraincon.png";
import HotIcon from "../../../../assets/smokecon.png";
import { Grid } from "@mui/material";
import "./WeatherCard.css";

type Props = {
  weather: Weather;
};

type WeatherIconDictionnary = {
  [key: string]: string;
};

const WeatherCard: React.FC<Props> = ({ weather }) => {
  const weatherIcons: WeatherIconDictionnary = {
    Windy: WindyIcon,
    WindyCloud: WindyCloudIcon,
    Sun: SunIcon,
    Snow: SnowIcon,
    Hot: HotIcon,
    PartyCloud: PartyCloudIcon,
    LightRain: LightrainIcon,
    Lightning: LightningIcon,
    HeavyRain: HeavyrainIcon,
    Cloud: CloudIcon,
  };

  return (
    <Grid item component={Card} xs={12} md={2} className="card weather">
      <CardContent>
        <CardMedia
          className="image"
          component="img"
          alt="WeatherIcon"
          image={weatherIcons[weather.summary]}
        />
        <Typography
          gutterBottom
          variant="h5"
          component="h2"
          align="center"
          noWrap
        >
          {weather.temperatureC}
        </Typography>
        <Typography
          variant="body2"
          color="textSecondary"
          align="center"
          component="p"
          noWrap
        >
          {weather.date}
        </Typography>
      </CardContent>
    </Grid>
  );
};

export default WeatherCard;
