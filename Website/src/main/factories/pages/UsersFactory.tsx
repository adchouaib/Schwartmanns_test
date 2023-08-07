import Users from "../../../presentation/pages/Users/Users";
import { makeCreateUser } from "../usecases/CreateUserFactory";
import { makeDeleteUser } from "../usecases/DeleteUserFactory";
import { makeLoadUserList } from "../usecases/LoadUserListFactory";

export const makeUsersPage: React.FC = () => {
  return (
    <Users
      loadUserList={makeLoadUserList()}
      createUser={makeCreateUser()}
      deleteUser={makeDeleteUser()}
    />
  );
};
