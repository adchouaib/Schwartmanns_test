import Login from "../../../presentation/pages/Login/Login";
import React from "react";
import { makeAuthentication } from "../usecases/Authenticate";
import { setCurrentAccount } from "../../../main/adapters/currentAccountAdapter";

export const makeLogin: React.FC = () => {
  return (
    <Login
      Authentication={makeAuthentication()}
      SetCurrentAccount={setCurrentAccount}
    />
  );
};
