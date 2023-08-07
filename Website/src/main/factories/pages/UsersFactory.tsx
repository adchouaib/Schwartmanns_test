import { Users } from "../../../presentation/pages";
import {
  makeCreateUser,
  makeDeleteUser,
  makeLoadUserList,
  makeUpdateUserPassword,
} from "../usecases";

export const makeUsersPage: React.FC = () => {
  return (
    <Users
      loadUserList={makeLoadUserList()}
      createUser={makeCreateUser()}
      deleteUser={makeDeleteUser()}
      updateUserPassword={makeUpdateUserPassword()}
    />
  );
};
