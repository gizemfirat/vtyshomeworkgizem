import Task from "../entities/Task";

type TaskSavingModel = {
  task : Task,
  sourceIds : number[],
}

export default TaskSavingModel;
