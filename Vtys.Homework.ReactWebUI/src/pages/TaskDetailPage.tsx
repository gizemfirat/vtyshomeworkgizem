import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Task from "../types/entities/Task";
import Project from "../types/entities/Project";
import TaskStatus from "../types/entities/TaskStatus";


const TaskDetailPage = () => {
  const navigate = useNavigate();
  const [task, setTask] = useState<Task>();
  const [projects, setProjects] = useState<Project[]>([]);
  const [taskStatuses, setTaskStatuses] = useState<TaskStatus[]>([]);


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (task) {
      if (task.id) {
        apiHelper.post<Task, Task>(`tasks`, task)
          .then(() => {})
      } else {
        apiHelper.post<Task, Task>('tasks', task)
          .then(() => {
          })
      }
    }
  };

  const handleProjectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedProjectId = parseInt(event.target.value);
    const selectedProject = projects.find(project => project.id === selectedProjectId);

    if (selectedProject && task) {
      setTask({ ...task, projectId: selectedProjectId});
    }
  };

  const handleTaskStatusChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedTaskStatusId = parseInt(event.target.value);
    const selectedTaskStatus = taskStatuses.find(taskStatus => taskStatus.id === selectedTaskStatusId);

    if (selectedTaskStatus && task) {
      setTask({ ...task, lastStatusId: selectedTaskStatusId});
    }
  };

  useEffect(() => {
    apiHelper.get<Task>(`tasks/${id}`).then((data) => {
      setTask(data);
    })
  }, [id])

  useEffect(() => {
    apiHelper.get<Project[]>("projects").then((data) => {
      setProjects(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<TaskStatus[]>("taskStatuses").then((data) => {
      setTaskStatuses(data);
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
                  <Typography fontWeight={500}>İşin Adı:</Typography>
                  <TextField
                    value={task?.name}
                    onChange={(e) => {
                      if (task) setTask({ ...task, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <label htmlFor="projectSelect">Proje Seç:</label>
                  <select id="projectSelect" onChange={handleProjectChange}>
                    {projects.map((project) => (
                      <option key={project.id} value={project.id}>
                        {project.name}
                      </option>
                    ))}
                  </select>
                </Grid>
                <Grid md={12}>
                  <label htmlFor="taskStatusSelect">İşin Durumunu Seç:</label>
                  <select
                    id="taskStatusSelect"
                    onChange={handleTaskStatusChange}
                  >
                    {taskStatuses.map((taskStatus) => (
                      <option key={taskStatus.id} value={taskStatus.id}>
                        {taskStatus.name}
                      </option>
                    ))}
                  </select>
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
export default TaskDetailPage;