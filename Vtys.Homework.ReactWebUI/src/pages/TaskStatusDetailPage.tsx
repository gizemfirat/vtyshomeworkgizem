import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import TaskStatus from "../types/entities/TaskStatus";


const TaskStatusDetailPage = () => {
  const navigate = useNavigate();
  const [taskStatus, setTaskStatus] = useState<TaskStatus>({id: 0, name: "", isFırst: false, isLast: false});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (taskStatus) {
      if (taskStatus.id) {
        apiHelper.post<TaskStatus, TaskStatus>(`taskStatuses`, taskStatus).then(() => {
          navigate("/taskStatus");
        });
      } else {
        apiHelper.post<TaskStatus, TaskStatus>("taskStatuses", taskStatus).then(() => {
          navigate("/taskStatus");
        });
      }
    }
  };

  useEffect(() => {
    apiHelper.get<TaskStatus>(`taskStatuses/${id}`).then((data) => {
      setTaskStatus(data);
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
                    value={taskStatus?.name}
                    onChange={(e) => {
                      if (taskStatus)
                        setTaskStatus({ ...taskStatus, name: e.target.value });
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
export default TaskStatusDetailPage;