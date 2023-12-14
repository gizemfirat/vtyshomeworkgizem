import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import TaskType from "../types/entities/TaskType";


const TaskTypeDetailPage = () => {
  const navigate = useNavigate();
  const [taskType, setTaskType] = useState<TaskType>({id: 0, name: ""});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (taskType) {
      if (taskType.id) {
        apiHelper.post<TaskType, TaskType>(`taskTypes`, taskType)
          .then(() => {})
      } else {
        apiHelper.post<TaskType, TaskType>('taskTypes', taskType)
          .then(() => {
          })
      }
    }
  };

  useEffect(() => {
    apiHelper.get<TaskType>(`taskTypes/${id}`).then((data) => {
      setTaskType(data);
    })
  }, [id])

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
                    label={"Ad"}
                    value={taskType?.name}
                    onChange={(e) => {
                      if (taskType)
                        setTaskType({ ...taskType, name: e.target.value });
                    }}
                  />
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
export default TaskTypeDetailPage;