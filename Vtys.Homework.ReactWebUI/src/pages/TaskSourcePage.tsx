import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";
import ProjectSource from "../types/entities/ProjectSource";
import TaskSource from "../types/entities/TaskSource";

const TaskSourcePage = () => {
  const navigate = useNavigate();

  const [taskSources, setTaskSources] = useState<TaskSource[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<TaskSource[]>("taskSources").then((data) => {
      setTaskSources(data);
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
                <Table sx={{ minWidth: 650 }} aria-label="taskSource table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Kaynak ID'si</TableCell>
                      <TableCell align="right">İş ID'si</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {taskSources.map((taskSource) => (
                      <TableRow key={taskSource.id}>
                        <TableCell align="right">{taskSource.id}</TableCell>
                        <TableCell align="right">{taskSource.sourceId}</TableCell>
                        <TableCell align="right">{taskSource.taskId}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(
                                `/taskSources/detail?id=${taskSource.id}`
                              );
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                           onClick={() => {
                            apiHelper.delete<void>(`taskSources/${taskSource.id}`).then( () => {
                              setTaskSources(taskSources.filter(x => x.id !== taskSource.id))
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
                        navigate(`/taskSources/detail`);
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
export default TaskSourcePage;