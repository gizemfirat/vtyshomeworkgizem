import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";
import ProjectSource from "../types/entities/ProjectSource";

const ProjectSourcePage = () => {
  const navigate = useNavigate();

  const [projectSources, setProjectSources] = useState<ProjectSource[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<ProjectSource[]>("projectSources").then((data) => {
      setProjectSources(data);
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
                <Table sx={{ minWidth: 650 }} aria-label="projectSource table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Kaynak ID'si</TableCell>
                      <TableCell align="right">Proje ID'si</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {projectSources.map((projectSource) => (
                      <TableRow key={projectSource.id}>
                        <TableCell align="right">{projectSource.id}</TableCell>
                        <TableCell align="right">{projectSource.sourceId}</TableCell>
                        <TableCell align="right">{projectSource.projectId}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(
                                `/projectSources/detail?id=${projectSource.id}`
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
                            apiHelper.delete<void>(`projectSources/${projectSource.id}`).then( () => {
                              setProjectSources(projectSources.filter(x => x.id !== projectSource.id))
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
                        navigate(`/projectSources/detail`);
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
export default ProjectSourcePage;