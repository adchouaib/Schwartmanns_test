import { User } from "@/domain/models";
import { IDeleteUser } from "@/domain/usecases";
import {
  Avatar,
  Box,
  IconButton,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import ChangeCircleIcon from "@mui/icons-material/ChangeCircle";
import { blue, grey, red } from "@mui/material/colors";
import React, { Dispatch, SetStateAction } from "react";

type Props = {
  users: User[];
  deleteUser: IDeleteUser;
  updateClickHandeler: () => void;
  setSelectedUser: Dispatch<SetStateAction<string>>;
  setsnackBarOpen: Dispatch<SetStateAction<boolean>>;
  setMessage: Dispatch<SetStateAction<string>>;
  setActionPerformed: Dispatch<SetStateAction<boolean>>;
};

const UserTable: React.FC<Props> = ({
  users,
  deleteUser,
  setsnackBarOpen,
  setMessage,
  setActionPerformed,
  setSelectedUser,
  updateClickHandeler,
}) => {
  const handleDelete = async (id: string) => {
    try {
      const res = await deleteUser.delete({
        id: id,
      });
      setActionPerformed(res);
      setMessage("User deleted");
      setsnackBarOpen(true);
    } catch (error) {
      console.error(error);
    }
  };

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
                      <Avatar sx={{ bgcolor: blue[700] }}>
                        {user.name[0].toUpperCase()}
                      </Avatar>
                    </IconButton>
                    <Typography variant="subtitle1">{user.name}</Typography>
                  </Stack>
                </TableCell>
                <TableCell>{user.email}</TableCell>
                <TableCell>
                  <Stack alignItems="center" direction="row" spacing={2}>
                    <IconButton
                      sx={{ p: 0 }}
                      onClick={() => {
                        setSelectedUser(user.id);
                        updateClickHandeler();
                      }}
                    >
                      <ChangeCircleIcon sx={{ color: grey[700] }} />
                    </IconButton>
                    <IconButton
                      sx={{ p: 0 }}
                      onClick={() => handleDelete(user.id)}
                    >
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
