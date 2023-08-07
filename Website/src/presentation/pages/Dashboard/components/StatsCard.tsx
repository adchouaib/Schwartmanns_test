import {
  Avatar,
  Card,
  CardContent,
  Stack,
  SvgIcon,
  Typography,
} from "@mui/material";
import React, { ReactNode } from "react";

type Props = {
  title: string;
  count: number;
  icon: ReactNode;
};

const StatsCard: React.FC<Props> = ({ title, count, icon }) => {
  return (
    <Card
      sx={{
        width: "100%",
      }}
    >
      <CardContent>
        <Stack
          alignItems="flex-start"
          direction="row"
          justifyContent="space-between"
          spacing={3}
        >
          <Stack spacing={1}>
            <Typography color="text.secondary" variant="overline">
              {title}
            </Typography>
            <Typography variant="h4">{count}</Typography>
          </Stack>
          <Avatar
            sx={{
              backgroundColor: "primary.main",
              height: 56,
              width: 56,
            }}
          >
            <SvgIcon>{icon}</SvgIcon>
          </Avatar>
        </Stack>
      </CardContent>
    </Card>
  );
};

export default StatsCard;
