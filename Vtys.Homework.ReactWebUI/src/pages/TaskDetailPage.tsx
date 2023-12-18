import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Paper, Select, TextField, Typography } from "@mui/material";
import Project from "../types/entities/Project";
import Task from "../types/entities/Task";
import TaskStatus from "../types/entities/TaskStatus";
import TaskType from "../types/entities/TaskType";
import SourceDetail from "../types/models/SourceDetail";
import TaskSavingModel from "../types/models/TaskSavingModel";


const TaskDetailPage = () => {
  const navigate = useNavigate();
  const [task, setTask] = useState<Task>({id: 0, name: "", lastStatusId: 0, taskTypeId: 0, projectId: 0});
  const [projects, setProjects] = useState<Project[]>([]);
  const [taskStatuses, setTaskStatuses] = useState<TaskStatus[]>([]);
  const [taskTypes, setTaskTypes] = useState<TaskType[]>([]);
  const [sources, setSources] = useState<SourceDetail[]>([]);
  const [sourceIds, setSourceIds] = useState<number[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    // if (task) {
    //   if (task.id) {
    //     apiHelper
    //       .post<TaskSavingModel, Task>(`tasks`, { task, sourceIds, projectId })
    //       .then(() => {
    //         navigate("/task");
    //       });
    //   } else {
    //     apiHelper
    //       .post<TaskSavingModel, Task>("tasks", { task, sourceIds, projectId })
    //       .then(() => {
    //         navigate("/task");
    //       });
    //   }
    // }
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
    apiHelper.get<SourceDetail[]>("sources").then((data) => {
      setSources(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<TaskStatus[]>("taskStatuses").then((data) => {
      setTaskStatuses(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<TaskType[]>("taskTypes").then((data) => {
      setTaskTypes(data);
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
                  <TextField
                    fullWidth
                    label={"Ad"}
                    value={task?.name}
                    onChange={(e) => {
                      if (task) setTask({ ...task, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Yer Alacağı Proje</InputLabel>
                    <Select
                      fullWidth
                      value={task.projectId}
                      label={"Yer Aldığı Proje"}
                      onChange={(e) => {
                        if (task)
                          setTask({
                            ...task,
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
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Kaynaklar</InputLabel>
                    <Select
                      multiple
                      fullWidth
                      label={"Kaynaklar"}
                      value={sourceIds}
                      onChange={(e) => {
                        setSourceIds(e.target.value as []);
                      }}
                    >
                      {sources.map((source) => (
                        <MenuItem key={source.id} value={source.id}>
                          {source.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>İş Tipi</InputLabel>
                    <Select
                      fullWidth
                      value={task.taskTypeId}
                      label={"İş Tipi"}
                      onChange={(e) => {
                        if (task)
                          setTask({
                            ...task,
                            taskTypeId: e.target.value as number,
                          });
                      }}
                    >
                      {taskTypes.map((taskType) => (
                        <MenuItem key={taskType.id} value={taskType.id}>
                          {taskType.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>İş Durumu</InputLabel>
                    <Select
                      fullWidth
                      value={task.lastStatusId}
                      label={"İş Durumu"}
                      onChange={(e) => {
                        if (task)
                          setTask({
                            ...task,
                            lastStatusId: e.target.value as number,
                          });
                      }}
                    >
                      {taskStatuses.map((taskStatus) => (
                        <MenuItem key={taskStatus.id} value={taskStatus.id}>
                          {taskStatus.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
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