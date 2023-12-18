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
import TaskSource from "../types/entities/TaskSource";


const TaskSourceDetailPage = () => {
  const navigate = useNavigate();
  const [taskSource, setTaskSource] = useState<TaskSource>({id: 0, sourceId: 0, taskId: 0});
  const [tasks, setTasks] = useState<Task[]>([]);
  const [sources, setSources] = useState<SourceDetail[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (taskSource) {
      if (taskSource.id) {
        apiHelper.post<TaskSource, TaskSource>(`taskSources`, taskSource)
          .then(() => {navigate("/taskSource");})
      } else {
        apiHelper.post<TaskSource, TaskSource>('taskSources', taskSource)
          .then(() => {navigate("/taskSource");
          })
      }
    }
  };

  useEffect(() => {
    apiHelper.get<TaskSource>(`taskSources/${id}`).then((data) => {
      setTaskSource(data);
    })
  }, [id])

  useEffect(() => {
    apiHelper.get<Task[]>("tasks").then((data) => {
      setTasks(data);
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
                    value={taskSource.taskId}
                    label={"Proje"}
                    onChange={(e) => {
                      if (taskSource)
                        setTaskSource({
                          ...taskSource,
                          taskId: e.target.value as number,
                        });
                    }}
                  >
                    {tasks.map((task) => (
                      <MenuItem key={task.id} value={task.id}>
                        {task.name}
                      </MenuItem>
                    ))}
                  </Select>
                </Grid>
                <Grid md={12}>
                  <Select
                    fullWidth
                    value={taskSource.sourceId}
                    label={"Kaynak"}
                    onChange={(e) => {
                      if (taskSource)
                        setTaskSource({
                          ...taskSource,
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
export default TaskSourceDetailPage;