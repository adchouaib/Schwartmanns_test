import { ILoadDashboardTotal, ILoadProjectsPerClient } from "@/domain/usecases";
import { Box, Container, Grid } from "@mui/material";
import React, { ReactNode, useEffect, useState } from "react";
import StatsCard from "./components/StatsCard";
import PersonIcon from "@mui/icons-material/Person";
import SupervisorAccountIcon from "@mui/icons-material/SupervisorAccount";
import DriveFolderUploadIcon from "@mui/icons-material/DriveFolderUpload";
import TaskIcon from "@mui/icons-material/Task";
import { ProjectPerClient, Stat } from "@/domain/models";
import GlobalStatsPieChart from "./components/GlobalStatsPieChart";
import ProjectsPerClientChart from "./components/ProjectsPerClientChart";

type Props = {
  loadDashboardTotal: ILoadDashboardTotal;
  loadProjectsPerClient: ILoadProjectsPerClient;
};

type IconMap = {
  [key: string]: ReactNode;
};

const Dashboard: React.FC<Props> = ({
  loadDashboardTotal,
  loadProjectsPerClient,
}) => {
  const [stats, setStats] = useState<Stat[]>([]);
  const [projectsPerClient, setProjectsPerClient] = useState<
    ProjectPerClient[]
  >([]);
  const iconList: IconMap = {
    Users: <PersonIcon />,
    Clients: <SupervisorAccountIcon />,
    Projects: <DriveFolderUploadIcon />,
    Jobs: <TaskIcon />,
  };

  useEffect(() => {
    loadDashboardTotal.loadAll().then((res) => setStats(res));
    loadProjectsPerClient.loadAll().then((res) => setProjectsPerClient(res));
  }, []);

  return (
    <Box
      component="main"
      sx={{
        flexGrow: 1,
        py: 3,
      }}
    >
      <Container maxWidth="xl">
        <Grid container spacing={2}>
          {stats.map((stat, i) => (
            <Grid key={`${stat.name}${i}`} item xs={12} sm={6} md={3}>
              <StatsCard
                title={stat.name}
                count={stat.stat}
                icon={iconList[stat.name]}
              />
            </Grid>
          ))}
          <Grid item xs={12} sm={12} md={6}>
            <GlobalStatsPieChart stats={stats} />
          </Grid>

          <Grid item xs={12} sm={12} md={6}>
            <ProjectsPerClientChart projects={projectsPerClient} />
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
};

export default Dashboard;
