import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import { Box, Button, Grid, Paper, Snackbar, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField } from "@mui/material";
import User from "../types/entities/User";

const LoginPage = () => {
  const navigate = useNavigate();

  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>(""); 

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
                      value={username}
                      label={"Kullanıcı Adı"}
                      onChange={(e) => setUsername(e.target.value)}
                    />
                  </Grid>
                  <Grid md={12}>
                    <TextField
                      fullWidth
                      value={password}
                      label={"Şifre"}
                      type="password"
                      onChange={(e) => setPassword(e.target.value)}
                    />
                  </Grid>
                  <Grid md={12}></Grid>
                  <Grid md={12}>
                    <Grid container justifyContent={"space-between"}>
                      <Grid item></Grid>
                      <Grid item>
                        <Button variant="contained" size="large">
                          Giriş Yap
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
export default LoginPage;