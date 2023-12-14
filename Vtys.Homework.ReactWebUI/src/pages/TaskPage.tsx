import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
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
        <Paper>
          <Box padding={2}>
            <Grid container gap={1}>
              <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="task table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">İş Adı</TableCell>
                      <TableCell align="right">Proje ID'si</TableCell>
                      <TableCell align="right">İş Tipi</TableCell>
                      <TableCell align="right">Son Durum</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {tasks.map((task) => (
                      <TableRow key={task.id}>
                        <TableCell align="right">{task.id}</TableCell>
                        <TableCell align="right">{task.name}</TableCell>
                        <TableCell align="right">{task.projectId}</TableCell>
                        <TableCell align="right">{task.taskTypeId}</TableCell>
                        <TableCell align="right">{task.lastStatusId}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/tasks/detail?id=${task.id}`);
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              apiHelper
                                .delete<void>(`tasks/${task.id}`)
                                .then(() => {
                                  setTasks(
                                    tasks.filter((x) => x.id !== task.id)
                                  );
                                });
                            }}
                            size="small"
                          >
                            Sil
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
              <Grid md={2}></Grid>
              <Grid md={12}>
                <Grid container justifyContent={"flex-end"} spacing={1}>
                  <Grid item>
                    <Button
                      variant="contained"
                      size="large"
                      onClick={() => {
                        navigate(`/tasks/detail`);
                      }}
                    >
                      Ekle
                    </Button>
                  </Grid>
                  <Grid item>
                    <Button
                      variant="contained"
                      size="large"
                      onClick={() => {
                        navigate(`/taskType`);
                      }}
                    >
                      İş Tipleri
                    </Button>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
          </Box>
        </Paper>
      </Grid>
    </Grid>
  );
}
export default TaskPage;