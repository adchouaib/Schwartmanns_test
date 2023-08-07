import { Switch, Route, Redirect } from "react-router-dom";
import {
  makeWeatherPage,
  makeUsersPage,
  makeLogin,
  makeDashboardPage,
} from "../factories/pages";
import PrivateRoute from "./private-routes";
import { useEffect, useState } from "react";
import { isTokenExpired, removeCurrentAccount } from "../adapters";

const Router: React.FC = () => {
  const [expired, setExpired] = useState(false);
  useEffect(() => {
    if (isTokenExpired()) {
      removeCurrentAccount();
      setExpired(true);
    } else {
      setExpired(false);
    }
  }, [expired]);
  return (
    <Switch>
      <Route path="/login" exact component={makeLogin} />
      <Route path="/" exact component={() => <Redirect to={"/home"} />} />
      <PrivateRoute path="/users" exact component={makeUsersPage} />
      <PrivateRoute path="/dashboard" exact component={makeDashboardPage} />
      <Route path="/home" exact component={makeWeatherPage} />
    </Switch>
  );
};

export default Router;
