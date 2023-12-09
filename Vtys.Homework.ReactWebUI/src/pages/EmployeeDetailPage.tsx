import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import apiHelper from "../helpers/apiHelper";
import Employee from "../types/entities/Employee";
import { Button, TextField } from "@mui/material";


const EmployeeDetailPage = () => {
  const navigate = useNavigate();
  const [employee, setEmployee] = useState<Employee>();

  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);

  const id = queryParams.get("id");

  const handleSubmit = () => {
    if (employee) {
      employee.id = 0;
      apiHelper.post<Employee, Employee>("employees", employee).then(() => {});
    }
  };

  useEffect(() => {
    apiHelper.get<Employee>(`employees/${id}`).then((data) => {
      setEmployee(data);
    })
  }, [id])

  return (
    <div>
      <TextField
        value={employee?.name}
        onChange={(e) => {
          if (employee) setEmployee({ ...employee, name : e.target.value});
        }}
      />
      <Button onClick={handleSubmit}>Kaydet</Button>
    </div>
  );
}
export default EmployeeDetailPage;