import { Switch, Route, Redirect } from "react-router-dom";
import { makeWeatherPage } from "../factories/pages";
import { makeLogin } from "../factories/pages/LoginFactory";
import PrivateRoute from "./private-routes";

const Router: React.FC = () => {
  return (
    <Switch>
      <Route path="/login" exact component={makeLogin} />
      <Route path="/" exact component={() => <Redirect to={"/home"} />} />
      <PrivateRoute path="/home" exact component={makeWeatherPage} />
    </Switch>
  );
};

export default Router;
