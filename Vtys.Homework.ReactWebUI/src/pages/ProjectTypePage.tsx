import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";
import TaskType from "../types/entities/TaskType";
import ProjectType from "../types/entities/ProjectType";

const ProjectTypePage = () => {
  const navigate = useNavigate();

  const [projectTypes, setProjectTypes] = useState<ProjectType[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<ProjectType[]>("projectTypes").then((data) => {
      setProjectTypes(data);
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
                <Table sx={{ minWidth: 650 }} aria-label="projectType table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Proje Adı</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {projectTypes.map((projectType) => (
                      <TableRow key={projectType.id}>
                        <TableCell align="right">{projectType.id}</TableCell>
                        <TableCell align="right">{projectType.name}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(
                                `/projectTypes/detail?id=${projectType.id}`
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
                            apiHelper.delete<void>(`projectTypes/${projectType.id}`).then( () => {
                              setProjectTypes(projectTypes.filter(x => x.id !== projectType.id))
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
                        navigate(`/projectTypes/detail`);
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
export default ProjectTypePage;