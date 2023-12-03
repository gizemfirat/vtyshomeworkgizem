import React, { useEffect, useState } from 'react';
import apiHelper from './helpers/apiHelper';
import Employee from './types/entities/Employee';
import RegisterModel from './types/models/RegisterModel';
import User from './types/entities/User';

const App =() => {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    apiHelper.get<Employee[]>("employees").then((data) => {
      setEmployees(data);
    })

    const registerModel: RegisterModel =  {
      name: "Gizem",
      surname: "Fırat",
      password: "12Ab34Cd$",
      passwordAgain: "12Ab34Cd$",
      email: "gizem.firat@abc.com",
      username: "gizem.firat"
    }

    apiHelper
      .post<RegisterModel, User>("security/register", registerModel)
      .then((user) => {
        console.log("user", user);
      });
  }, [])

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Surname</th>
          </tr>
        </thead>
        <tbody>
          {employees.map(employee => {
            return (
              <tr>
                <td>{employee.name}</td>
                <td>{employee.surname}</td>
              </tr>
            );
          })}
        </tbody>
      </table> 
    </div>
  );
}

export default App;
