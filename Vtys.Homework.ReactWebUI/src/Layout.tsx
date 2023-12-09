import { AppBar, Box, Button, Grid, Toolbar, Typography } from "@mui/material";
import React from "react";
import { Outlet, useNavigate } from "react-router-dom";

const Layout = () => {
  const navigate = useNavigate();

  const handleNavigation = (path:string) => {
    navigate(path);
  };
  return (
    <div>
      <Box sx={{ flexGrow: 1 }}>
        <AppBar position="fixed">
          <Toolbar>
            <Typography variant="h5" component="div" sx={{ flexGrow: 1 }}>
              G.E.
            </Typography>
            <Button
              color="inherit"
              onClick={() => handleNavigation("/department")}
            >
              Departmanlar
            </Button>
            <Button
              color="inherit"
              onClick={() => handleNavigation("/employee")}
            >
              Çalışanlar
            </Button>
            <Button
              color="inherit"
              onClick={() => handleNavigation("/machine")}
            >
              Makineler
            </Button>
            <Button
              color="inherit"
              onClick={() => handleNavigation("/project")}
            >
              Projeler
            </Button>
            <Button color="inherit" onClick={() => handleNavigation("/task")}>
              İş Bölümleri
            </Button>
          </Toolbar>
        </AppBar>
      </Box>
      <Grid marginTop={12}>
        <Grid md={4}></Grid>
        <Grid md={8}>
          <Outlet />
        </Grid>
      </Grid>
    </div>
  );
}

export default Layout;