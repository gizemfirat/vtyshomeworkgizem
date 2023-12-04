import { Alert, Box, Button, Grid, Paper, Snackbar, TextField } from "@mui/material";
import React, { useEffect, useState } from "react";
import SendIcon from "@mui/icons-material/Send";
import RegisterModel from "../types/models/RegisterModel";
import User from "../types/entities/User";
import apiHelper from "../helpers/apiHelper";
import { useNavigate } from "react-router-dom";

const RegisterPage = () => {
  const navigate = useNavigate();

  const [isAlertOpen, setIsAlertOpen] = useState<boolean>(false);
  const [alertMessage, setAlertMessage] = useState<string>("");

  const [name, setName] = useState<string>("");
  const [surname, setSurname] = useState<string>(""); 
  const [username, setUsername] = useState<string>(""); 
  const [email, setEmail] = useState<string>(""); 
  const [password, setPassword] = useState<string>(""); 
  const [passwordAgain, setPasswordAgain] = useState<string>("");

  const [isPasswordsMatch, setIsPasswordsMatch] = useState<boolean>(true);

  useEffect(() => {
      setIsPasswordsMatch(password === passwordAgain);
  }, [password, passwordAgain]);

  const handleAlertClose = () => {
    setIsAlertOpen(false);
  }

  const showMessage = (message:string) => {
    setAlertMessage(message);
    setIsAlertOpen(true);
  }
  const handleSubmit = () => {
    const registerModel: RegisterModel = {
      name,
      surname,
      password,
      passwordAgain,
      email,
      username,
    };

    apiHelper
      .post<RegisterModel, User>("security/register", registerModel)
      .then((user) => {
        navigate("/");
      })
      .catch((message: string) => {
        showMessage(message);
      });
  };

  return (
    <div>
      <Snackbar
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        open={isAlertOpen}
        autoHideDuration={6000}
        onClose={handleAlertClose}
      >
        <Alert onClose={handleAlertClose} severity="error">
          {alertMessage}
        </Alert>
      </Snackbar>
      <Grid marginTop={6} container>
        <Grid md={4}></Grid>
        <Grid md={4}>
          <Paper>
            <Box padding={2}>
              <Grid container gap={2}>
                <Grid md={12}>
                  <TextField
                    fullWidth
                    value={name}
                    label={"Ad"}
                    onChange={(e) => setName(e.target.value)}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    fullWidth
                    value={surname}
                    label={"Soyad"}
                    onChange={(e) => setSurname(e.target.value)}
                  />
                </Grid>
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
                    value={email}
                    label={"E-Mail"}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    fullWidth
                    value={password}
                    label={"Şifre"}
                    type="password"
                    onChange={(e) => setPassword(e.target.value)}
                    error={!isPasswordsMatch}
                  />
                </Grid>
                <Grid md={12}>
                  <TextField
                    fullWidth
                    value={passwordAgain}
                    label={"Yeniden Şifre"}
                    type="password"
                    onChange={(e) => setPasswordAgain(e.target.value)}
                    error={!isPasswordsMatch}
                  />
                </Grid>
                <Grid md={12}>
                  <Grid container justifyContent={"space-between"}>
                    <Grid item></Grid>
                    <Grid item>
                      <Button
                        variant="contained"
                        size="large"
                        endIcon={<SendIcon />}
                        onClick={handleSubmit}
                      >
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

export default RegisterPage;