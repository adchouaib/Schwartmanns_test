import React from "react";
import ReactDOM from "react-dom/client";
import Router from "./main/routes/router";
import Navbar from "./presentation/components/Navbar";
import { BrowserRouter } from "react-router-dom";
import { RecoilRoot } from "recoil";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RecoilRoot>
      <BrowserRouter>
        <Navbar />
        <Router />
      </BrowserRouter>
    </RecoilRoot>
  </React.StrictMode>
);
