import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Customer from "../types/entities/Customer";
import Department from "../types/entities/Department";


const DepartmentDetailPage = () => {
  const navigate = useNavigate();
  const [department, setDepartment] = useState<Department>({id: 0, name: ""});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (department) {
      if (department.id) {
        apiHelper.post<Department, Department>(`departments`, department).then(() => {
          navigate("/department");
        });
      } else {
        apiHelper.post<Department, Department>("departments", department).then(() => {
          navigate("/department");
        });
      }
    }
  };

  useEffect(() => {
    apiHelper.get<Department>(`departments/${id}`).then((data) => {
      setDepartment(data);
    })
  }, [id])

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
                    label={"Ad"}
                    value={department?.name}
                    onChange={(e) => {
                      if (department)
                        setDepartment({ ...department, name: e.target.value });
                    }}
                  />
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
export default DepartmentDetailPage;