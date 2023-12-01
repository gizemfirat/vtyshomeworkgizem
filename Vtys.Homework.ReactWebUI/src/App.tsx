import React, { useEffect, useState } from 'react';
import apiHelper from './helpers/apiHelper';
import Employee from './types/entities/Employee';

const App =() => {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    apiHelper.get<Employee[]>("employees").then((data) => {
      setEmployees(data);
    })
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
