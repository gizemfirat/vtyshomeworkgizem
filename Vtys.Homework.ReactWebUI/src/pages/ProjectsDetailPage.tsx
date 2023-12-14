import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Accordion, AccordionDetails, AccordionSummary, Badge, Box, Button, Card, Chip, Grid, List, ListItem, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography } from "@mui/material";
import Department from "../types/entities/Department";
import ProjectDetail from "../types/models/ProjectDetail";
import TaskDetail from "../types/models/TaskDetail";
import styled from "styled-components";
import { Source } from "@mui/icons-material";

const ListItemComponent = styled(ListItem)`
  &:not(:last-child){
    border-bottom: 1px solid #bababa;
  }
`;

const ChipComponent = styled(Chip)`
  &:not(:last-child){
    margin-right: 2px;
  }
`;

const ProjectsDetailPage = () => {
  const navigate = useNavigate();

  const [projects, setProjects] = useState<ProjectDetail[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<ProjectDetail[]>("projects/detail").then((data) => {
      setProjects(data);
    });
  }, []);

  const CardInfo = ({ label, value }: { label: string; value: any }) => {
    return (
      <ListItemComponent>
        <Grid container>
          <Grid md={4}>
            <Typography fontWeight={600}>{label}</Typography>
          </Grid>
          <Grid md={8}>
            <Typography>{value}</Typography>
          </Grid>
        </Grid>
      </ListItemComponent>
    );
  };

  const TaskCard = ({task}: {task: TaskDetail}) => {
    const employees = task.sources.filter(Source => Source.sourceTypeId == 1);
    const machines = task.sources.filter(Source => Source.sourceTypeId == 2);
    return (
      <Accordion>
        <AccordionSummary>{task.name}</AccordionSummary>
        <AccordionDetails>
          <Grid container>
            <Grid md={12}>
              <List>
                <CardInfo
                  label="Çalışanlar"
                  value={
                    <>
                      {employees.map((employee) => (
                        <ChipComponent color="primary" label={employee.name}/>
                      ))}
                    </>
                  }
                />
                <CardInfo
                  label="Makineler"
                  value={
                    <>
                      {machines.map((machine) => (
                        <ChipComponent color="success" label={machine.name}/>
                      ))}
                    </>
                  }
                />
              </List>
            </Grid>
          </Grid>
        </AccordionDetails>
      </Accordion>
    );
  }
  const ProjectCard = ({ project }: { project: ProjectDetail }) => {
    return (
      <Accordion>
        <AccordionSummary>{project.name}</AccordionSummary>
        <AccordionDetails>
          <Grid container gap={2}>
            <Grid md={12}>
              <List>
                <CardInfo label="Başlangıç Tarihi" value={project.startDate} />
                <CardInfo label="Bitiş Tarihi" value={project.finishDate} />
                <CardInfo
                  label="İşler"
                  value={
                    <Grid container gap={2}>
                      {project.tasks.map((task) => (
                        <Grid md={12}>
                          <TaskCard task={task} />
                        </Grid>
                      ))}
                    </Grid>
                  }
                />
              </List>
            </Grid>
          </Grid>
        </AccordionDetails>
      </Accordion>
    );
  };

  return (
    <div>
      <Grid container gap={2}>
        {projects.map((project) => (
          <Grid md={12}>
            <ProjectCard project={project} />
          </Grid>
        ))}
      </Grid>
    </div>
  );
};
export default ProjectsDetailPage;