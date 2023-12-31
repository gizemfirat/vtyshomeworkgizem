﻿using Vtys.Core.Aspects;
using Vtys.Core.Business.Concrete;
using Vtys.Core.Results;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.Business.Concrete
{
    public class EmployeeManager : Manager, IEmployeeService
    {
        private readonly IGetEmployeesQuery _getEmployeesQuery;
        public EmployeeManager(IGetEmployeesQuery getEmployeesQuery)
        {
            _getEmployeesQuery = getEmployeesQuery;
        }

        [ExceptionResultAspect]
        public IResult GetAll()
        {
            var employees = _getEmployeesQuery.Run();
            return new SuccessResult("", employees);
        }

        [ExceptionResultAspect]
        public IResult GetById(long id) 
        {
            var employee = Repository.Get<Employee>(x => x.Id == id);
            return new SuccessResult("", employee);
        }

        [ExceptionResultAspect]
        public IResult Save(Employee employee)
        {
            employee = employee.Id == 0
                ? Repository.Add(employee)
                : Repository.Update(employee);

            return new SuccessResult("", employee);
        }

        [ExceptionResultAspect]
        public IResult DeleteById(long id) 
        {
            var employee = Repository.Get<Employee>(x => x.Id == id);
            if (employee != null)
            {
                Repository.Delete(employee);
            }
            return new SuccessResult("Employee deleted successfully!");
        }
    }
}
