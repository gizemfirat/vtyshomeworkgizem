import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Task from "../types/entities/Task";

const TaskPage = () => {
  const navigate = useNavigate();

  const [tasks, setTasks] = useState<Task[]>([]);

  useEffect(() => {
    apiHelper.get<Task[]>("tasks").then((data) => {
      setTasks(data);
    })
  }, [])

  return (
    <Grid marginTop={12} container>
      <Grid md={2}></Grid>
      <Grid md={8}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="task table">
            <TableHead>
              <TableRow>
                <TableCell align="right">ID</TableCell>
                <TableCell align="right">İş Adı</TableCell>
                <TableCell align="right">Proje ID'si</TableCell>
                <TableCell align="right">İş Durumu ID'si</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {tasks.map((task) => (
                <TableRow key={task.id}>
                  <TableCell align="right">{task.id}</TableCell>
                  <TableCell align="right">{task.name}</TableCell>
                  <TableCell align="right">{task.projectId}</TableCell>
                  <TableCell align="right">{task.lastStatusId}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid md={2}></Grid>
    </Grid>
  );
}
export default TaskPage;