import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import TaskStatus from "../types/entities/TaskStatus";

const TaskStatusPage = () => {
  const navigate = useNavigate();

  const [taskStatuses, setTaskStatuses] = useState<TaskStatus[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<TaskStatus[]>("taskStatuses").then((data) => {
      setTaskStatuses(data);
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
                <Table sx={{ minWidth: 900 }} aria-label="taskstatus table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Ad</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {taskStatuses.map((taskStatus) => (
                      <TableRow key={taskStatus.id}>
                        <TableCell align="right">{taskStatus.id}</TableCell>
                        <TableCell align="right">{taskStatus.name}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/taskStatuses/detail?id=${taskStatus.id}`);
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              apiHelper.delete<void>(`taskStatuses/${taskStatus.id}`).then( () => {
                                setTaskStatuses(taskStatuses.filter(x => x.id !== taskStatus.id))
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
                        navigate(`/taskStatuses/detail`);
                      }}
                    >
                      Ekle
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
export default TaskStatusPage;