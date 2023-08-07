import { Route, RouteProps, Redirect } from "react-router-dom";
import { getCurrentAccount } from "../adapters/currentAccountAdapter";

const PrivateRoute: React.FC<RouteProps> = (props: RouteProps) => {
  const currentAccount = getCurrentAccount();
  return currentAccount ? (
    <Route {...props} />
  ) : (
    <Route {...props} component={() => <Redirect to="/login" />} />
  );
};

export default PrivateRoute;
