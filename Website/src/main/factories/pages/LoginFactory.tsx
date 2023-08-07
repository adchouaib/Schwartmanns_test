import { Login } from "../../../presentation/pages";
import React from "react";
import { makeAuthentication } from "../usecases/Authenticate";
import { setCurrentAccount } from "../../../main/adapters";

export const makeLogin: React.FC = () => {
  return (
    <Login
      Authentication={makeAuthentication()}
      SetCurrentAccount={setCurrentAccount}
    />
  );
};
