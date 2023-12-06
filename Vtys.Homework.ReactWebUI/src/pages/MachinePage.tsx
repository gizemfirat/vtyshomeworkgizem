import React, { useEffect, useState } from "react";
import Machine from "../types/entities/Machine";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

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
      <Grid md={3}></Grid>
      <Grid md={6}>
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
                  <TableCell align="right">{machine.serialNumber}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid md={3}></Grid>
    </Grid>
  );
}
export default MachinePage;