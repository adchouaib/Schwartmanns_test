import {
  Box,
  Button,
  Container,
  Stack,
  SvgIcon,
  Typography,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { User } from "../../../domain/models/User";
import { ILoadUserList } from "../../../domain/usecases/ILoadUserList";
import React, { useEffect, useState } from "react";
import UserTable from "./components/UserTable";
import UserForm from "./components/UserForm";
import { ICreateUser } from "../../../domain/usecases/ICreateUser";
import SnackBar from "./components/Snackbar";
import { IDeleteUser } from "../../../domain/usecases/IDeleteUser";

type Props = {
  loadUserList: ILoadUserList;
  createUser: ICreateUser;
  deleteUser: IDeleteUser;
};

const Users: React.FC<Props> = ({ loadUserList, createUser, deleteUser }) => {
  const [users, setUsers] = useState<User[]>([]);
  const [actionPerformed, setActionPerformed] = useState<boolean>(false);
  const [message, setMessage] = useState<string>("");
  const [snackBarOpen, setsnackBarOpen] = useState(false);
  const [loading, setLoading] = useState<boolean>(false);
  const [open, setOpen] = useState<boolean>(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  useEffect(() => {
    setLoading(true);
    loadUserList
      .loadAll()
      .then((res) => setUsers(res))
      .then(() => setLoading(false));
    setActionPerformed(false);
  }, [loadUserList, actionPerformed]);

  return (
    <Box
      component="main"
      sx={{
        flexGrow: 1,
        py: 3,
      }}
    >
      <Container maxWidth="xl">
        <SnackBar
          message={message}
          open={snackBarOpen}
          setMessage={setMessage}
          setOpen={setsnackBarOpen}
        />
        <UserForm
          setActionPerformed={setActionPerformed}
          createUser={createUser}
          setsnackBarOpen={setsnackBarOpen}
          setMessage={setMessage}
          handleClose={handleClose}
          open={open}
        />
        <Stack spacing={3}>
          <Stack direction="row" justifyContent="space-between" spacing={4}>
            <Stack spacing={1}>
              <Typography variant="h4">Users</Typography>
            </Stack>
            <div>
              <Button
                startIcon={
                  <SvgIcon fontSize="small">
                    <AddIcon />
                  </SvgIcon>
                }
                variant="contained"
                onClick={handleClickOpen}
              >
                Add
              </Button>
            </div>
          </Stack>
          {loading ? (
            <div>loading</div>
          ) : (
            <UserTable
              users={users}
              deleteUser={deleteUser}
              setMessage={setMessage}
              setsnackBarOpen={setsnackBarOpen}
              setActionPerformed={setActionPerformed}
            />
          )}
        </Stack>
      </Container>
    </Box>
  );
};

export default Users;
