import { useRoutes } from "react-router-dom";
import RegisterPage from "../pages/RegisterPage";
import Layout from "../Layout";
import EmployeePage from "../pages/EmployeePage";
import MachinePage from "../pages/MachinePage";
import ProjectPage from "../pages/ProjectPage";
import TaskPage from "../pages/TaskPage";
import DepartmentPage from "../pages/DepartmentPage";
import LoginPage from "../pages/LoginPage";
import EmployeeDetailPage from "../pages/EmployeeDetailPage";
import DepartmentDetailPage from "../pages/DepartmentDetailPage";
import MachineDetailPage from "../pages/MachineDetailPage";
import ProjectsDetailPage from "../pages/ProjectsDetailPage";

const Routes = () => useRoutes([{
  path:"/",
  element: <Layout/>,
  children: [
    {path: "", element: <></>},
    {path: "register", element: <RegisterPage/>},
    {path: "employee", element: <EmployeePage/>},
    {path: "machine", element: <MachinePage/>},
    {path: "project", element: <ProjectPage/>},
    {path: "task", element: <TaskPage/>},
    {path: "department", element: <DepartmentPage/>},
    {path: "login", element: <LoginPage/>},
    {path: "employees/detail", element: <EmployeeDetailPage/>},
    {path: "departments/detail", element: <DepartmentDetailPage/>},
    {path: "machines/detail", element: <MachineDetailPage/>},
    {path: "projects/detail", element: <ProjectsDetailPage/>}
  ]
}]);

export default Routes;