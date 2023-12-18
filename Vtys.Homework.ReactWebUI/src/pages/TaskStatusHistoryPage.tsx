import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import TaskStatus from "../types/entities/TaskStatus";
import TaskStatusHistoryDetail from "../types/models/TaskStatusHistoryDetail";
import moment from "moment";

const TaskStatusHistoryPage = () => {
  const navigate = useNavigate();

  const [taskStatusHistories, setTaskStatusHistories] = useState<TaskStatusHistoryDetail[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const taskId = queryParams.get("id");

  useEffect(() => {
    apiHelper.get<TaskStatusHistoryDetail[]>(`tasks/${taskId}/history`).then((data) => {
      setTaskStatusHistories(data);
    })
  }, [])

  return (
    <Grid container>
      <Grid md={2}></Grid>
      <Grid md={8}>
        <Paper>
          <Box padding={2}>
            <Grid container gap={1}>
              <TableContainer component={Paper}>
                <Table sx={{ minWidth: 900 }} aria-label="taskstatushistory table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">İş Durumu</TableCell>
                      <TableCell align="right">Yapılma Tarihi</TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {taskStatusHistories.map((taskStatusHistory, index) => (
                      <TableRow key={index}>
                        <TableCell align="right">{taskStatusHistory.name}</TableCell>
                        <TableCell align="right">{moment(taskStatusHistory.date).format('DD MM YYYY HH:mm')}</TableCell>
                        <TableCell align="right">
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
              <Grid md={2}></Grid>
            </Grid>
          </Box>
        </Paper>
      </Grid>
    </Grid>
  );
}
export default TaskStatusHistoryPage;