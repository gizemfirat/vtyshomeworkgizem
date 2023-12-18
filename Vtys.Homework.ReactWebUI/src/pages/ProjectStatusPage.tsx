import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import ProjectStatus from "../types/entities/ProjectStatus";

const ProjectStatusPage = () => {
  const navigate = useNavigate();

  const [projectStatuses, setProjectStatuses] = useState<ProjectStatus[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<ProjectStatus[]>("projectStatuses").then((data) => {
      setProjectStatuses(data);
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
                <Table sx={{ minWidth: 900 }} aria-label="projectstatus table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Ad</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {projectStatuses.map((projectStatus) => (
                      <TableRow key={projectStatus.id}>
                        <TableCell align="right">{projectStatus.id}</TableCell>
                        <TableCell align="right">{projectStatus.name}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/projectStatuses/detail?id=${projectStatus.id}`);
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              apiHelper.delete<void>(`projectStatuses/${projectStatus.id}`).then( () => {
                                setProjectStatuses(projectStatuses.filter(x => x.id !== projectStatus.id))
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
                        navigate(`/projectStatuses/detail`);
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
export default ProjectStatusPage;