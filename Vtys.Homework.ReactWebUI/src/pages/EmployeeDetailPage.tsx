import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, Grid, Paper, TextField } from "@mui/material";
import Department from "../types/entities/Department";


const EmployeeDetailPage = () => {
  const navigate = useNavigate();
  const [employee, setEmployee] = useState<Employee>();
  const [departments, setDepartments] = useState<Department[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (employee) {
      //employee.id = 0;
      apiHelper.post<Employee, Employee>("employees", employee).then(() => {});
    }
  };

  const handleDepartmentChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedDepartmentId = parseInt(event.target.value);
    const selectedDepartment = departments.find(department => department.id === selectedDepartmentId);

    if (selectedDepartment && employee) {
      setEmployee({ ...employee, departmentId: selectedDepartmentId});
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
                    value={employee?.name}
                    onChange={(e) => {
                      if (employee)
                        setEmployee({ ...employee, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    value={employee?.surname}
                    onChange={(e) => {
                      if (employee)
                        setEmployee({ ...employee, surname: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <label htmlFor="departmentSelect">Departman Seç:</label>
                  <select id="departmentSelect" onChange={handleDepartmentChange}>
                    {departments.map((department) => (
                      <option key={department.id} value={department.id}>
                        {department.name}
                      </option>
                    ))}
                  </select>
                </Grid>
                <Grid md={12}>
                  <Grid container justifyContent={"space-between"}>
                    <Grid item></Grid>
                    <Grid item>
                      <Button onClick={handleSubmit}>Kaydet</Button>
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