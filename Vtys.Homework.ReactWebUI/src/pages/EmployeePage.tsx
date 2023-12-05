import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

const EmployeePage = () => {
  const navigate = useNavigate();

  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    apiHelper.get<Employee[]>("employees").then((data) => {
      setEmployees(data);
    })
  }, [])

  return (
    <Grid marginTop={12} container>
      <Grid md={1}></Grid>
      <Grid md={10}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="employee table">
            <TableHead>
              <TableRow>
                <TableCell>ID</TableCell>
                <TableCell>Ad</TableCell>
                <TableCell>Soyad</TableCell>
                <TableCell align="right">Departman ID'si</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {employees.map((employee) => (
                <TableRow key={employee.id}>
                  <TableCell>{employee.id}</TableCell>
                  <TableCell>{employee.name}</TableCell>
                  <TableCell>{employee.surname}</TableCell>
                  <TableCell align="right">{employee.departmentId}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid md={1}></Grid>
    </Grid>
  );
}
export default EmployeePage;