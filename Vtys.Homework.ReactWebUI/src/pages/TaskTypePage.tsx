import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";
import TaskType from "../types/entities/TaskType";

const TaskTypePage = () => {
  const navigate = useNavigate();

  const [taskTypes, setTaskTypes] = useState<TaskType[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<TaskType[]>("taskTypes").then((data) => {
      setTaskTypes(data);
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
                <Table sx={{ minWidth: 650 }} aria-label="taskType table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">İş Adı</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {taskTypes.map((taskType) => (
                      <TableRow key={taskType.id}>
                        <TableCell align="right">{taskType.id}</TableCell>
                        <TableCell align="right">{taskType.name}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(
                                `/taskTypes/detail?id=${taskType.id}`
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
                            apiHelper.delete<void>(`taskTypes/${taskType.id}`).then( () => {
                              setTaskTypes(taskTypes.filter(x => x.id !== taskType.id))
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
                        navigate(`/taskTypes/detail`);
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
export default TaskTypePage;