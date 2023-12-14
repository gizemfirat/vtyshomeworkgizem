import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import Customer from "../types/entities/Customer";

const CustomerPage = () => {
  const navigate = useNavigate();

  const [customers, setCustomers] = useState<Customer[]>([]);
  const [showAddForm, setShowAddForm] = useState(false);

  useEffect(() => {
    apiHelper.get<Customer[]>("customers").then((data) => {
      setCustomers(data);
    })
  }, [])

  return (
    <Grid marginTop={12} container>
      <Grid md={2}></Grid>
      <Grid md={8}>
        <Paper>
          <Box padding={2}>
            <Grid container gap={1}>
              <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="customer table">
                  <TableHead>
                    <TableRow>
                      <TableCell align="right">ID</TableCell>
                      <TableCell align="right">Müşteri Adı</TableCell>
                      <TableCell align="right"></TableCell>
                      <TableCell align="right"></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {customers.map((customer) => (
                      <TableRow key={customer.id}>
                        <TableCell align="right">{customer.id}</TableCell>
                        <TableCell align="right">{customer.name}</TableCell>
                        <TableCell align="right">
                          <Button
                            onClick={() => {
                              navigate(
                                `/customers/detail?id=${customer.id}`
                              );
                            }}
                            size="small"
                          >
                            Düzenle
                          </Button>
                        </TableCell>
                        <TableCell align="right">
                          <Button
                           onClick={() => {
                            apiHelper.delete<void>(`customers/${customer.id}`).then( () => {
                              setCustomers(customers.filter(x => x.id !== customer.id))
                            });
                          }}
                            size="small"
                          >
                            Sil
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
              <Grid md={2}></Grid>
              <Grid md={12}>
                <Grid container justifyContent={"flex-end"} spacing={1}>
                  <Grid item>
                  <Button
                      variant="contained"
                      size="large"
                      onClick={() => {
                        navigate(`/customers/detail`);
                      }}
                    >
                      Ekle
                    </Button>
                  </Grid>
                </Grid>
              </Grid>
            </Grid>
          </Box>
        </Paper>
      </Grid>
    </Grid>
  );
}
export default CustomerPage;