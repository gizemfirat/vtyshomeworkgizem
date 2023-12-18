import Task from "../entities/Task";

type TaskSavingModel = {
  task : Task,
  sourceIds : number[],
  projectId: number
}

export default TaskSavingModel;
