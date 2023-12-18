import Project from "../entities/Project";

type ProjectSavingModel = {
  project : Project,
  sourceIds : number[]
}

export default ProjectSavingModel;
