import React, { useEffect, useState } from 'react';
import apiHelper from './helpers/apiHelper';
import Employee from './types/entities/Employee';
import RegisterModel from './types/models/RegisterModel';
import User from './types/entities/User';
import RegisterPage from './pages/RegisterPage';
import { BrowserRouter } from 'react-router-dom';
import Routes from './routes';
import { LocalizationProvider } from '@mui/x-date-pickers';
import dayjs from 'dayjs';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';

const App =() => {


  return (
    <LocalizationProvider dateAdapter={AdapterMoment}>
      <BrowserRouter>
        <Routes />
      </BrowserRouter>
    </LocalizationProvider>
  );
}

export default App;
