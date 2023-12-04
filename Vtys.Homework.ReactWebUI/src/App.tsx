import React, { useEffect, useState } from 'react';
import apiHelper from './helpers/apiHelper';
import Employee from './types/entities/Employee';
import RegisterModel from './types/models/RegisterModel';
import User from './types/entities/User';
import RegisterPage from './pages/RegisterPage';
import { BrowserRouter } from 'react-router-dom';
import Routes from './routes';

const App =() => {


  return (
    <div>
      <BrowserRouter>
        <Routes />
      </BrowserRouter>
    </div>
  );
}

export default App;
