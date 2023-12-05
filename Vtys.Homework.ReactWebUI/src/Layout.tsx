import { AppBar, Box, Button, Grid, Toolbar, Typography } from "@mui/material";
import React from "react";
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <div>
      <Box sx={{ flexGrow: 1 }}>
        <AppBar position="fixed">
          <Toolbar>
            <Typography variant="h5" component="div" sx={{ flexGrow: 1 }}>
              G.E.
            </Typography>
            <Button color="inherit">Kaynak Yönetimi</Button>
            <Button color="inherit">Proje Yönetimi</Button>
          </Toolbar>
        </AppBar>
      </Box>
      <Grid md={4}>
      </Grid>
      <Grid md={8}>
        <Outlet />
      </Grid>
    </div>
  );
}

export default Layout;