import { BrowserRouter, Routes, Route } from "react-router-dom";
import { makeWeatherPage } from "../factories/pages";

const Router: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={makeWeatherPage}></Route>
        <Route path="/home" Component={makeWeatherPage}></Route>
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
