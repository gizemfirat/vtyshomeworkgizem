import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Department from "../types/entities/Department";

const DepartmentPage = () => {
  const navigate = useNavigate();

  const [departments, setDepartments] = useState<Department[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<Department[]>("departments").then((data) => {
      setDepartments(data);
    })
  }, [])

  return (
    <Grid marginTop={12} container>
      <Grid md={2}></Grid>
      <Grid md={8}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="department table">
            <TableHead>
              <TableRow>
                <TableCell align="right">ID</TableCell>
                <TableCell align="right">Departman Adı</TableCell>

              </TableRow>
            </TableHead>
            <TableBody>
              {departments.map((department) => (
                <TableRow key={department.id}>
                  <TableCell align="right">{department.id}</TableCell>
                  <TableCell align="right">{department.name}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid md={2}></Grid>
      <Grid md={10}>
        <Grid container justifyContent={"flex-end"} marginTop={1} spacing={1}>
          <Grid item >
          <Button variant="contained" size="large">
            Ekle
          </Button>
          </Grid>
          <Grid item >
          <Button variant="contained" size="large">
            Sil
          </Button>
          </Grid>
          <Grid item >
          <Button variant="contained" size="large">
            Güncelle
          </Button>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
}
export default DepartmentPage;