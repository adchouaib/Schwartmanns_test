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

type Props = {
  loadUserList: ILoadUserList;
};

const Users: React.FC<Props> = ({ loadUserList }) => {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    console.log("making request" + import.meta.env.VITE_API_URL);
    setLoading(true);
    loadUserList
      .loadAll()
      .then((res) => setUsers(res))
      .then(() => setLoading(false));
  }, [loadUserList]);

  return (
    <Box
      component="main"
      sx={{
        flexGrow: 1,
        py: 3,
      }}
    >
      <Container maxWidth="xl">
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
              >
                Add
              </Button>
            </div>
          </Stack>
          {loading ? <div>loading</div> : <UserTable users={users} />}
        </Stack>
      </Container>
    </Box>
  );
};

export default Users;
