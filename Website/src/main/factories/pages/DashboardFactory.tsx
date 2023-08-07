// BUG: import should be @/presentation/pages
import React from "react";
import { makeLoadDashboardTotal } from "../usecases";
import { Dashboard } from "../../../presentation/pages";

export const makeDashboardPage: React.FC = () => {
  return <Dashboard loadDashboardTotal={makeLoadDashboardTotal()} />;
};
