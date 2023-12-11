import SourceDetail from "./SourceDetail";
import TaskDetail from "./TaskDetail";

type ProjectDetail = {
  id: number,
  name: string,
  tasks: TaskDetail[],
  startDate: string,
  finishDate: string
}

export default ProjectDetail;