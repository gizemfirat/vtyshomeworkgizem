import Project from "../entities/Project";

type ProjectWithSourceIds = {
  project : Project,
  sourceIds: number[]
}

export default ProjectWithSourceIds;