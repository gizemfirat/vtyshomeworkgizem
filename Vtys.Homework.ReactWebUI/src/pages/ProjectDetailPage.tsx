import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Paper, Select, TextField, Typography } from "@mui/material";
import Project from "../types/entities/Project";
import SourceDetail from "../types/models/SourceDetail";
import Customer from "../types/entities/Customer";
import ProjectStatus from "../types/entities/ProjectStatus";
import ProjectType from "../types/entities/ProjectType";
import ProjectSavingModel from "../types/models/ProjectSavingModel";
import ProjectWithSourceIds from "../types/models/ProjectWithSourceIds";
import { DateTimePicker } from "@mui/x-date-pickers";
import moment from "moment";


const ProjectDetailPage = () => {
  const navigate = useNavigate();
  const [project, setProject] = useState<Project>({id: 0, name: "", customerId: 0 , lastStatusId: 0, projectTypeId: 0, startDate: new Date(), finishDate: new Date()});
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [projectStatuses, setProjectStatuses] = useState<ProjectStatus[]>([]);
  const [projectTypes, setProjectTypes] = useState<ProjectType[]>([]);
  const [sources, setSources] = useState<SourceDetail[]>([]);
  const [sourceIds, setSourceIds] = useState<number[]>([]);

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (project) {
      if (project.id) {
        apiHelper
          .post<ProjectSavingModel, Project>(`projects`, {project, sourceIds})
          .then(() => {
            navigate("/project");
          });
      } else {
        apiHelper
          .post<ProjectSavingModel, Project>("projects", {project, sourceIds})
          .then(() => {
            navigate("/project");
          });
      }
    }
  };

  useEffect(() => {
    if (id)
      apiHelper.get<ProjectWithSourceIds>(`projects/${id}`).then((data) => {
        setProject(data.project);
        setSourceIds(data.sourceIds);
      });
  }, [id]);

  useEffect(() => {
    apiHelper.get<Customer[]>("customers").then((data) => {
      setCustomers(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<SourceDetail[]>("sources").then((data) => {
      setSources(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<ProjectStatus[]>("projectStatuses").then((data) => {
      setProjectStatuses(data);
    })
  }, [])

  useEffect(() => {
    apiHelper.get<ProjectType[]>("projectTypes").then((data) => {
      setProjectTypes(data);
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
                    value={project?.name}
                    onChange={(e) => {
                      if (project) setProject({ ...project, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <DateTimePicker
                    label="Başlangıç Tarihi"
                    value={moment(project.startDate)}
                    onChange={(newValue) => {
                      if (project)
                        setProject({
                          ...project,
                          startDate: newValue?.toDate() ?? new Date(),
                        });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <DateTimePicker
                    label="Bitiş Tarihi"
                    value={moment(project.finishDate)}
                    onChange={(newValue) => {
                      if (project)
                        setProject({
                          ...project,
                          finishDate: newValue?.toDate() ?? new Date(),
                        });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Müşteriler</InputLabel>
                    <Select
                      fullWidth
                      value={project.customerId}
                      label={"Müşteriler"}
                      onChange={(e) => {
                        if (project)
                          setProject({
                            ...project,
                            customerId: e.target.value as number,
                          });
                      }}
                    >
                      {customers.map((customer) => (
                        <MenuItem key={customer.id} value={customer.id}>
                          {customer.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Kaynaklar</InputLabel>
                    <Select
                      multiple
                      fullWidth
                      label={"Kaynaklar"}
                      value={sourceIds}
                      onChange={(e) => {
                        setSourceIds(e.target.value as []);
                      }}
                    >
                      {sources.map((source) => (
                        <MenuItem key={source.id} value={source.id}>
                          {source.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Proje Tipi</InputLabel>
                    <Select
                      fullWidth
                      value={project.projectTypeId}
                      label={"Proje Tipi"}
                      onChange={(e) => {
                        if (project)
                          setProject({
                            ...project,
                            projectTypeId: e.target.value as number,
                          });
                      }}
                    >
                      {projectTypes.map((projectType) => (
                        <MenuItem key={projectType.id} value={projectType.id}>
                          {projectType.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid md={12}>
                  <FormControl fullWidth>
                    <InputLabel>Proje Durumu</InputLabel>
                    <Select
                      fullWidth
                      value={project.lastStatusId}
                      label={"Proje Durumu"}
                      onChange={(e) => {
                        if (project)
                          setProject({
                            ...project,
                            lastStatusId: e.target.value as number,
                          });
                      }}
                    >
                      {projectStatuses.map((projectStatus) => (
                        <MenuItem key={projectStatus.id} value={projectStatus.id}>
                          {projectStatus.name}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
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
export default ProjectDetailPage;