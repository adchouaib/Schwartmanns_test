import Users from "../../../presentation/pages/Users/Users";
import { makeLoadUserList } from "../usecases/LoadUserListFactory";

export const makeUsersPage: React.FC = () => {
  return <Users loadUserList={makeLoadUserList()} />;
};
