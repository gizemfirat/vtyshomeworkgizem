import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, Grid, MenuItem, Paper, Select, TextField, Typography } from "@mui/material";
import Department from "../types/entities/Department";


const EmployeeDetailPage = () => {
  const navigate = useNavigate();
  const [employee, setEmployee] = useState<Employee>({id: 0, name: "", surname: "", departmentId: 0});
  const [departments, setDepartments] = useState<Department[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (employee) {
      if (employee.id) {
        apiHelper.post<Employee, Employee>(`employees`, employee)
          .then(() => {navigate("/employee");})
      } else {
        apiHelper.post<Employee, Employee>("employees", employee).then(() => {
          navigate("/employee");
        });
      }
    }
  };

  useEffect(() => {
    apiHelper.get<Employee>(`employees/${id}`).then((data) => {
      setEmployee(data);
    })
  }, [id])

  useEffect(() => {
    apiHelper.get<Department[]>("departments").then((data) => {
      setDepartments(data);
    })
  }, [])

  return (
    <div>
      <Grid marginTop={12} container>
        <Grid md={4}></Grid>
        <Grid md={4}>
          <Paper>
            <Box padding={2}>
              <Grid container gap={2}>
                <Grid md={12}>
                  <TextField
                    fullWidth
                    label={"Ad"}
                    value={employee?.name}
                    onChange={(e) => {
                      if (employee)
                        setEmployee({ ...employee, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    label={"Soyad"}
                    fullWidth
                    value={employee?.surname}
                    onChange={(e) => {
                      if (employee)
                        setEmployee({ ...employee, surname: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <Select
                    fullWidth
                    value={employee.departmentId}
                    label={"Departman"}
                    onChange={(e) => {
                      if (employee)
                        setEmployee({
                          ...employee,
                          departmentId: e.target.value as number,
                        });
                    }}
                  >
                    {departments.map((department) => (
                      <MenuItem key={department.id} value={department.id}>
                        {department.name}
                      </MenuItem>
                    ))}
                  </Select>
                </Grid>
                <Grid md={12}>
                  <Grid container justifyContent={"space-between"}>
                    <Grid item></Grid>
                    <Grid item>
                      <Button variant="contained" onClick={handleSubmit}>
                        Kaydet
                      </Button>
                    </Grid>
                  </Grid>
                </Grid>
              </Grid>
            </Box>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
export default EmployeeDetailPage;