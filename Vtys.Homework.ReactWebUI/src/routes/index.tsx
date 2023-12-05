import { useRoutes } from "react-router-dom";
import RegisterPage from "../pages/RegisterPage";
import Layout from "../Layout";
import EmployeePage from "../pages/EmployeePage";
import MachinePage from "../pages/MachinePage";

const Routes = () => useRoutes([{
  path:"/",
  element: <Layout/>,
  children: [
    {path: "", element: <></>},
    {path: "register", element: <RegisterPage/>},
    {path: "employee", element: <EmployeePage/>},
    {path: "machine", element: <MachinePage/>},
  ]
}]);

export default Routes;