import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, Grid, MenuItem, Paper, Select, TextField, Typography } from "@mui/material";
import Project from "../types/entities/Project";
import Task from "../types/entities/Task";
import TaskStatus from "../types/entities/TaskStatus";
import TaskType from "../types/entities/TaskType";
import ProjectSource from "../types/entities/ProjectSource";
import SourceDetail from "../types/models/SourceDetail";
import Source from "../types/entities/Source";


const ProjectSourceDetailPage = () => {
  const navigate = useNavigate();
  const [projectSource, setProjectSource] = useState<ProjectSource>({id: 0, sourceId: 0, projectId: 0});
  const [projects, setProjects] = useState<Project[]>([]);
  const [sources, setSources] = useState<SourceDetail[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (projectSource) {
      if (projectSource.id) {
        apiHelper.post<ProjectSource, ProjectSource>(`projectSources`, projectSource)
          .then(() => {navigate("/projectSource");})
      } else {
        apiHelper.post<ProjectSource, ProjectSource>('projectSources', projectSource)
          .then(() => {navigate("/projectSource");
          })
      }
    }
  };

  useEffect(() => {
    apiHelper.get<ProjectSource>(`projectSources/${id}`).then((data) => {
      setProjectSource(data);
    })
  }, [id])

  useEffect(() => {
    apiHelper.get<Project[]>("projects").then((data) => {
      setProjects(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<SourceDetail[]>("sources").then((data) => {
      setSources(data);
    })
  }, [])

  return (
    <div>
      <Grid marginTop={12} container>
        <Grid md={4}></Grid>
        <Grid md={4}>
          <Paper>
            <Box padding={2}>
              <Grid container gap={2}>
                <Grid md={12}>
                  <Select
                    fullWidth
                    value={projectSource.projectId}
                    label={"Proje"}
                    onChange={(e) => {
                      if (projectSource)
                        setProjectSource({
                          ...projectSource,
                          projectId: e.target.value as number,
                        });
                    }}
                  >
                    {projects.map((project) => (
                      <MenuItem key={project.id} value={project.id}>
                        {project.name}
                      </MenuItem>
                    ))}
                  </Select>
                </Grid>
                <Grid md={12}>
                  <Select
                    fullWidth
                    value={projectSource.sourceId}
                    label={"Kaynak"}
                    onChange={(e) => {
                      if (projectSource)
                        setProjectSource({
                          ...projectSource,
                          sourceId: e.target.value as number,
                        });
                    }}
                  >
                    {sources.map((source) => (
                      <MenuItem key={source.id} value={source.id}>
                        {source.name}
                      </MenuItem>
                    ))}
                  </Select>
                </Grid>
                <Grid md={12}>
                  <Grid container justifyContent={"space-between"}>
                    <Grid item></Grid>
                    <Grid item>
                      <Button variant="contained" onClick={handleSubmit}>
                        Kaydet
                      </Button>
                    </Grid>
                  </Grid>
                </Grid>
              </Grid>
            </Box>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
export default ProjectSourceDetailPage;