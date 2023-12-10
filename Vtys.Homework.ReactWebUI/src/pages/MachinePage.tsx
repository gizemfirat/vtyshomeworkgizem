import React, { useEffect, useState } from "react";
import Machine from "../types/entities/Machine";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

const MachinePage = () => {
  const navigate = useNavigate();

  const [machines, setMachines] = useState<Machine[]>([]);

  useEffect(() => {
    apiHelper.get<Machine[]>("machines").then((data) => {
      setMachines(data);
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
                <Table sx={{ minWidth: 650 }} aria-label="machine table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Seri Numarası</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {machines.map((machine) => (
                      <TableRow key={machine.id}>
                        <TableCell align="right">{machine.id}</TableCell>
                        <TableCell align="right">
                          {machine.serialNumber}
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/machines/detail?id=${machine.id}`);
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/machines/detail?id=${machine.id}`);
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
                        navigate(`/machines/detail`);
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
export default MachinePage;