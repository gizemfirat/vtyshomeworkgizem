import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Machine from "../types/entities/Machine";


const MachineDetailPage = () => {
  const navigate = useNavigate();
  const [machine, setMachine] = useState<Machine>({id: 0, name: "", serialNumber: 0});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (machine) {
      if (machine.id) {
        apiHelper.post<Machine, Machine>(`machines`, machine).then(() => {
          navigate("/machine");
        });
      } else {
        apiHelper.post<Machine, Machine>("machines", machine).then(() => {
          navigate("/machine");
        });
      }
    }
  };

  useEffect(() => {
    if (id) {
      apiHelper.get<Machine>(`machines/${id}`).then((data) => {
        setMachine(data);
      });
    }
  }, [id]);

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
                    value={machine.name}
                    fullWidth
                    onChange={(e) => {
                      if (machine)
                        setMachine({ ...machine, name: e.target.value });
                    }}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    label={"Seri Numarası"}
                    type="number"
                    value={machine.serialNumber}
                    fullWidth
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