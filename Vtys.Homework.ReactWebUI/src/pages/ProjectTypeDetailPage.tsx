import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import ProjectType from "../types/entities/ProjectType";


const ProjectTypeDetailPage = () => {
  const navigate = useNavigate();
  const [projectType, setProjectType] = useState<ProjectType>({id: 0, name: ""});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (projectType) {
      if (projectType.id) {
        apiHelper.post<ProjectType, ProjectType>(`projectTypes`, projectType)
          .then(() => {navigate("/projectType");})
      } else {
        apiHelper.post<ProjectType, ProjectType>('projectTypes', projectType)
          .then(() => {navigate("/projectType");
          })
      }
    }
  };

  useEffect(() => {
    apiHelper.get<ProjectType>(`projectTypes/${id}`).then((data) => {
      setProjectType(data);
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
                    value={projectType?.name}
                    onChange={(e) => {
                      if (projectType)
                        setProjectType({ ...projectType, name: e.target.value });
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
export default ProjectTypeDetailPage;