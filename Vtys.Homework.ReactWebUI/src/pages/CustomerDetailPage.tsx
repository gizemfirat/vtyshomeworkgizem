import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Customer from "../types/entities/Customer";


const CustomerDetailPage = () => {
  const navigate = useNavigate();
  const [customer, setCustomer] = useState<Customer>({id: 0, name: ""});


  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (customer) {
      if (customer.id) {
        apiHelper.post<Customer, Customer>(`customers`, customer).then(() => {
          navigate("/customer");
        });
      } else {
        apiHelper.post<Customer, Customer>("customers", customer).then(() => {
          navigate("/customer");
        });
      }
    }
  };

  useEffect(() => {
    apiHelper.get<Customer>(`customers/${id}`).then((data) => {
      setCustomer(data);
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
                    value={customer?.name}
                    onChange={(e) => {
                      if (customer)
                        setCustomer({ ...customer, name: e.target.value });
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
export default CustomerDetailPage;