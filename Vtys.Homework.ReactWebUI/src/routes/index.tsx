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
import TaskDetailPage from "../pages/TaskDetailPage";
import CustomerPage from "../pages/CustomerPage";
import TaskTypePage from "../pages/TaskTypePage";
import ProjectTypePage from "../pages/ProjectTypePage";
import CustomerDetailPage from "../pages/CustomerDetailPage";
import ProjectTypeDetailPage from "../pages/ProjectTypeDetailPage";
import TaskTypeDetailPage from "../pages/TaskTypeDetailPage";
import ProjectDetailPage from "../pages/ProjectDetailPage";
import ProjectSourcePage from "../pages/ProjectSourcePage";
import ProjectSourceDetailPage from "../pages/ProjectSourceDetailPage";
import TaskSourcePage from "../pages/TaskSourcePage";
import TaskSourceDetailPage from "../pages/TaskSourceDetailPage";
import ProjectStatusPage from "../pages/ProjectStatusPage";
import ProjectStatusDetailPage from "../pages/ProjectStatusDetailPage";
import TaskStatusPage from "../pages/TaskStatusPage";
import TaskStatusDetailPage from "../pages/TaskStatusDetailPage";

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
    {path: "projects/detail", element: <ProjectsDetailPage/>},
    {path: "tasks/detail", element: <TaskDetailPage/>},
    {path: "customer", element: <CustomerPage/>},
    {path: "taskType", element: <TaskTypePage/>},
    {path: "projectType", element: <ProjectTypePage/>},
    {path: "customers/detail", element: <CustomerDetailPage/>},
    {path: "projectTypes/detail", element: <ProjectTypeDetailPage/>},
    {path: "taskTypes/detail", element: <TaskTypeDetailPage/>},
    {path: "project/detail", element: <ProjectDetailPage/>},
    {path: "projectSource", element: <ProjectSourcePage/>},
    {path: "projectSources/detail", element: <ProjectSourceDetailPage/>},
    {path: "taskSource", element: <TaskSourcePage/>},
    {path: "taskSources/detail", element: <TaskSourceDetailPage/>},
    {path: "projectStatus", element: <ProjectStatusPage/>},
    {path: "projectStatuses/detail", element: <ProjectStatusDetailPage/>},
    {path: "taskStatus", element: <TaskStatusPage/>},
    {path: "taskStatuses/detail", element: <TaskStatusDetailPage/>},
  ]
}]);

export default Routes;