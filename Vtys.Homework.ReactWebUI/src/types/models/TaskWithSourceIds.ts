import Task from "../entities/Task";

type TaskWithSourceIds = {
  task : Task,
  sourceIds: number[]
}

export default TaskWithSourceIds;