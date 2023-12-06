import { useRoutes } from "react-router-dom";
import RegisterPage from "../pages/RegisterPage";
import Layout from "../Layout";
import EmployeePage from "../pages/EmployeePage";
import MachinePage from "../pages/MachinePage";
import ProjectPage from "../pages/ProjectPage";
import TaskPage from "../pages/TaskPage";

const Routes = () => useRoutes([{
  path:"/",
  element: <Layout/>,
  children: [
    {path: "", element: <></>},
    {path: "register", element: <RegisterPage/>},
    {path: "employee", element: <EmployeePage/>},
    {path: "machine", element: <MachinePage/>},
    {path: "project", element: <ProjectPage/>},
    {path: "task", element: <TaskPage/>}
  ]
}]);

export default Routes;