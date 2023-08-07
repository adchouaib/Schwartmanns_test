import {
  Box,
  Button,
  Container,
  Stack,
  SvgIcon,
  Typography,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { User } from "@/domain/models";
import {
  ILoadUserList,
  ICreateUser,
  IDeleteUser,
  IUpdateUserPassword,
} from "@/domain/usecases";
import React, { useEffect, useState } from "react";
import UserTable from "./components/UserTable";
import UserForm from "./components/UserForm";
import SnackBar from "./components/Snackbar";
import UpdatePasswordForm from "./components/UpdatePasswordForm";

type Props = {
  loadUserList: ILoadUserList;
  createUser: ICreateUser;
  deleteUser: IDeleteUser;
  updateUserPassword: IUpdateUserPassword;
};

const Users: React.FC<Props> = ({
  loadUserList,
  createUser,
  deleteUser,
  updateUserPassword,
}) => {
  const [users, setUsers] = useState<User[]>([]);
  const [actionPerformed, setActionPerformed] = useState<boolean>(false);
  const [message, setMessage] = useState<string>("");
  const [snackBarOpen, setsnackBarOpen] = useState(false);
  const [loading, setLoading] = useState<boolean>(false);
  const [selectedUser, setSelectedUser] = useState<string>("");

  //userForm
  const [userFormOpen, setUserFormOpen] = useState<boolean>(false);
  const handleUserFormClickOpen = () => {
    setUserFormOpen(true);
  };
  const handleUserFormClose = () => {
    setUserFormOpen(false);
  };

  //updatePasswordForm
  const [updatePasswordOpen, setupdatePasswordOpen] = useState<boolean>(false);
  const handleUpdatePassClickOpen = () => {
    setupdatePasswordOpen(true);
  };
  const handleUpdatePassClose = () => {
    setupdatePasswordOpen(false);
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
        <UpdatePasswordForm
          userId={selectedUser}
          setActionPerformed={setActionPerformed}
          updateUserPassword={updateUserPassword}
          setsnackBarOpen={setsnackBarOpen}
          setMessage={setMessage}
          handleClose={handleUpdatePassClose}
          open={updatePasswordOpen}
        />
        <UserForm
          setActionPerformed={setActionPerformed}
          createUser={createUser}
          setsnackBarOpen={setsnackBarOpen}
          setMessage={setMessage}
          handleClose={handleUserFormClose}
          open={userFormOpen}
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
                onClick={handleUserFormClickOpen}
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
              updateClickHandeler={handleUpdatePassClickOpen}
              setSelectedUser={setSelectedUser}
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
