import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";
import ProjectSource from "../types/entities/ProjectSource";
import SourceDetail from "../types/models/SourceDetail";
import TaskSourceDetail from "../types/models/TaskSourceDetail";

const TaskSourcePage = () => {
  const navigate = useNavigate();

  const [taskSources, setTaskSources] = useState<TaskSourceDetail[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<TaskSourceDetail[]>("taskSources").then((data) => {
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
                      <TableCell align="right">Kaynak Adı</TableCell>
                      <TableCell align="right">İş Adı</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {taskSources.map((taskSource) => (
                      <TableRow key={taskSource.id}>
                        <TableCell align="right">{taskSource.id}</TableCell>
                        <TableCell align="right">{taskSource.sourceName}</TableCell>
                        <TableCell align="right">{taskSource.taskName}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
              <Grid md={2}></Grid>
              <Grid md={12}>
                <Grid container justifyContent={"flex-end"} spacing={1}>
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