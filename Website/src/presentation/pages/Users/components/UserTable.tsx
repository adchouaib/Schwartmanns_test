import { User } from "../../../../domain/models/User";
import {
  Avatar,
  Box,
  Container,
  IconButton,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { blue, grey, red } from "@mui/material/colors";
import React from "react";
import DeleteIcon from "@mui/icons-material/Delete";
import ChangeCircleIcon from "@mui/icons-material/ChangeCircle";

type Props = {
  users: User[];
};

const UserTable: React.FC<Props> = ({ users }) => {
  return (
    <Box sx={{ overflow: "scroll" }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Email</TableCell>
            <TableCell>Action</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {users.map((user) => {
            return (
              <TableRow hover key={user.name}>
                <TableCell>
                  <Stack alignItems="center" direction="row" spacing={2}>
                    <IconButton sx={{ p: 0 }}>
                      <Avatar
                        alt={user.name.toUpperCase()}
                        src="/static/images/avatar/2.jpg"
                        sx={{ bgcolor: blue[700] }}
                      />
                    </IconButton>
                    <Typography variant="subtitle1">{user.name}</Typography>
                  </Stack>
                </TableCell>
                <TableCell>{user.email}</TableCell>
                <TableCell>
                  <Stack alignItems="center" direction="row" spacing={2}>
                    <IconButton sx={{ p: 0 }}>
                      <ChangeCircleIcon sx={{ color: grey[700] }} />
                    </IconButton>
                    <IconButton sx={{ p: 0 }}>
                      <DeleteIcon sx={{ color: red[700] }} />
                    </IconButton>
                  </Stack>
                </TableCell>
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
    </Box>
  );
};

export default UserTable;
