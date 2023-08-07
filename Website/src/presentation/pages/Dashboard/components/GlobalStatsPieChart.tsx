import React from "react";
import Chart from "react-apexcharts";
import {
  Box,
  Card,
  CardContent,
  CardHeader,
  Stack,
  Typography,
  useTheme,
} from "@mui/material";
import { Stat } from "@/domain/models";

type Props = {
  stats: Stat[];
};

const useChartOptions = (labels: string[]) => {
  const theme = useTheme();

  return {
    chart: {
      background: "transparent",
    },
    colors: [
      theme.palette.primary.main,
      theme.palette.success.main,
      theme.palette.warning.main,
    ],
    dataLabels: {
      enabled: false,
    },
    labels,
    legend: {
      show: false,
    },
    plotOptions: {
      pie: {
        expandOnClick: false,
      },
    },
    states: {
      active: {
        filter: {
          type: "none",
        },
      },
      hover: {
        filter: {
          type: "none",
        },
      },
    },
    stroke: {
      width: 0,
    },
    theme: {
      mode: theme.palette.mode,
    },
    tooltip: {
      fillSeriesColor: false,
    },
  };
};

const GlobalStatsPieChart: React.FC<Props> = ({ stats }) => {
  const chartOptions = useChartOptions(stats.map((stat) => stat.name));
  return (
    <Card
      sx={{
        height: "100%",
      }}
    >
      <CardHeader title="Total Entities" />
      <CardContent>
        <Chart
          height={300}
          options={chartOptions}
          series={stats.map((stat) => stat.stat)}
          type="donut"
          width="100%"
        />
        <Stack
          alignItems="center"
          direction="row"
          justifyContent="center"
          spacing={2}
          sx={{ mt: 2 }}
        >
          {stats.map((item) => {
            const label = item.name;
            return (
              <Box
                key={label}
                sx={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "center",
                }}
              >
                <Typography sx={{ my: 1 }} variant="h6">
                  {label}
                </Typography>
                <Typography color="text.secondary" variant="subtitle2">
                  {item.stat}
                </Typography>
              </Box>
            );
          })}
        </Stack>
      </CardContent>
    </Card>
  );
};

export default GlobalStatsPieChart;
