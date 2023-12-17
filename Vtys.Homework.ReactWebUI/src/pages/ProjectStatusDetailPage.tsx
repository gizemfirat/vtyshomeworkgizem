import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Customer from "../types/entities/Customer";
import ProjectStatus from "../types/entities/ProjectStatus";


const ProjectStatusDetailPage = () => {
  const navigate = useNavigate();
  const [projectStatus, setProjectStatus] = useState<ProjectStatus>({id: 0, name: "", isFırst: false, isLast: false});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (projectStatus) {
      if (projectStatus.id) {
        apiHelper.post<ProjectStatus, ProjectStatus>(`projectStatuses`, projectStatus).then(() => {
          navigate("/projectStatus");
        });
      } else {
        apiHelper.post<ProjectStatus, ProjectStatus>("projectStatuses", projectStatus).then(() => {
          navigate("/projectStatus");
        });
      }
    }
  };

  useEffect(() => {
    apiHelper.get<ProjectStatus>(`projectStatus/${id}`).then((data) => {
      setProjectStatus(data);
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
                    value={projectStatus?.name}
                    onChange={(e) => {
                      if (projectStatus)
                        setProjectStatus({ ...projectStatus, name: e.target.value });
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
export default ProjectStatusDetailPage;