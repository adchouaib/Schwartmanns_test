import { ProjectPerClient } from "@/domain/models";
import React from "react";
import Chart from "react-apexcharts";
import { alpha, useTheme } from "@mui/material/styles";
import { Card, CardContent } from "@mui/material";

type Props = {
  projects: ProjectPerClient[];
};

const useChartOptions = (categories: string[]) => {
  const theme = useTheme();

  return {
    chart: {
      background: "transparent",
      stacked: false,
      toolbar: {
        show: false,
      },
    },
    colors: [
      theme.palette.primary.main,
      alpha(theme.palette.primary.main, 0.25),
    ],
    dataLabels: {
      enabled: false,
    },
    fill: {
      opacity: 1,
      type: "solid",
    },
    grid: {
      borderColor: theme.palette.divider,
      strokeDashArray: 2,
      xaxis: {
        lines: {
          show: false,
        },
      },
      yaxis: {
        lines: {
          show: true,
        },
      },
    },
    legend: {
      show: false,
    },
    plotOptions: {
      bar: {
        columnWidth: "40px",
      },
    },
    stroke: {
      colors: ["transparent"],
      show: true,
      width: 2,
    },
    theme: {
      mode: theme.palette.mode,
    },
    xaxis: {
      axisBorder: {
        color: theme.palette.divider,
        show: true,
      },
      axisTicks: {
        color: theme.palette.divider,
        show: true,
      },
      categories,
      labels: {
        offsetY: 5,
        style: {
          colors: theme.palette.text.secondary,
        },
      },
    },
    yaxis: {
      labels: {
        offsetX: 1,
        style: {
          colors: theme.palette.text.secondary,
        },
      },
    },
  };
};

const ProjectsPerClientChart: React.FC<Props> = ({ projects }) => {
  const projectCount: number[] = projects.reduce((acc, project) => {
    acc.push(project.projectcount);
    return acc;
  }, [] as number[]);
  console.log(projects);
  console.log(projectCount);

  const chartOptions = useChartOptions(
    projects.reduce((acc, project) => {
      acc.push(project.clientName);
      return acc;
    }, [] as string[])
  );
  return (
    <Card
      sx={{
        height: "100%",
      }}
    >
      <CardContent>
        <Chart
          height={350}
          options={chartOptions}
          series={[
            {
              name: "Projects",
              data: projectCount,
            },
          ]}
          type="bar"
          width="100%"
        />
      </CardContent>
    </Card>
  );
};

export default ProjectsPerClientChart;
