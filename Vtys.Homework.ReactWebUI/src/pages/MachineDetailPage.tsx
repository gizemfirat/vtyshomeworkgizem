import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Machine from "../types/entities/Machine";


const MachineDetailPage = () => {
  const navigate = useNavigate();
  const [machine, setMachine] = useState<Machine>();


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (machine) {
      if (machine.id) {
        apiHelper.post<Machine, Machine>(`machines`, machine)
          .then(() => {})
      } else {
        apiHelper.post<Machine, Machine>('machines', machine)
          .then(() => {
          })
      }
    }
  };

  useEffect(() => {
    apiHelper.get<Machine>(`machines/${id}`).then((data) => {
      setMachine(data);
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
                  <Typography fontWeight={500}>Makine Adı:</Typography>
                  <TextField
                    value={machine?.name}
                    onChange={(e) => {
                      if (machine)
                        setMachine({ ...machine, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <Typography fontWeight={500}>Seri Numarası:</Typography>
                  <TextField
                    type="number"
                    value={machine?.serialNumber}
                    onChange={(e) => {
                      if (machine)
                        setMachine({
                          ...machine,
                          serialNumber: parseInt(e.target.value),
                        });
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
export default MachineDetailPage;