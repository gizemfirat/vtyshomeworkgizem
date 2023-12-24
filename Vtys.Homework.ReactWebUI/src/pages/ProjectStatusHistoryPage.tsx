import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import TaskStatus from "../types/entities/TaskStatus";
import TaskStatusHistoryDetail from "../types/models/TaskStatusHistoryDetail";
import moment from "moment";
import ProjectStatusHistoryDetail from "../types/models/ProjectStatusHistoryDetail";

const ProjectStatusHistoryPage = () => {
  const navigate = useNavigate();

  const [projectStatusHistories, setProjectStatusHistories] = useState<ProjectStatusHistoryDetail[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const projectId = queryParams.get("id");

  useEffect(() => {
    apiHelper.get<ProjectStatusHistoryDetail[]>(`projects/${projectId}/history`).then((data) => {
      setProjectStatusHistories(data);
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
                <Table sx={{ minWidth: 900 }} aria-label="projectstatushistory table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">Proje Durumu</TableCell>
                      <TableCell align="right">Yapılma Tarihi</TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {projectStatusHistories.map((projectStatusHistory, index) => (
                      <TableRow key={index}>
                        <TableCell align="right">{projectStatusHistory.name}</TableCell>
                        <TableCell align="right">{moment(projectStatusHistory.date).format('DD MM YYYY HH:mm')}</TableCell>
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
export default ProjectStatusHistoryPage;