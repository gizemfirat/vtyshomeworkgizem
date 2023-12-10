import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";

const EmployeePage = () => {
  const navigate = useNavigate();

  const [employees, setEmployees] = useState<Employee[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<Employee[]>("employees").then((data) => {
      setEmployees(data);
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
                <Table sx={{ minWidth: 900 }} aria-label="employee table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Ad</TableCell>
                      <TableCell align="right">Soyad</TableCell>
                      <TableCell align="right">Departman ID'si</TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {employees.map((employee) => (
                      <TableRow key={employee.id}>
                        <TableCell align="right">{employee.id}</TableCell>
                        <TableCell align="right">{employee.name}</TableCell>
                        <TableCell align="right">{employee.surname}</TableCell>
                        <TableCell align="right">
                          {employee.departmentId}
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/employees/detail?id=${employee.id}`);
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(`/employees/detail?id=${employee.id}`);
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
export default EmployeePage;