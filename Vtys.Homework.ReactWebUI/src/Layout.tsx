import { AppBar, Box, Button, Grid, Menu, MenuItem, Toolbar, Typography } from "@mui/material";
import React from "react";
import { Outlet, useNavigate } from "react-router-dom";
import NavMenuItem from "./components/NavMenuItem";

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
              onClick={() => handleNavigation("/customer")}
            >
              Müşteriler
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
            <NavMenuItem
              label="Proje Yönetimi"
              items={[
                { label: "Proje Listesi", value: "/project" },
                { label: "Proje Tipleri", value: "/projectType" },
                { label: "Proje Raporu", value: "/projects/detail" },
                { label: "Proje Kaynakları", value: "/projectSource" },
                { label: "Proje Durumları", value: "/projectStatus"},
              ]}
              onClick={(value) => handleNavigation(value)}
            />
             <NavMenuItem
              label="İş Yönetimi"
              items={[
                { label: "İş Listesi", value: "/task" },
                { label: "İş Tipleri", value: "/taskType" },
                { label: "İş Kaynakları", value: "/taskSource" },
                { label: "İş Durumları", value: "/taskStatus"},
                { label: "İş Durumu Geçmişi", value: "/taskStatusHistory"},
              ]}
              onClick={(value) => handleNavigation(value)}
            />
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