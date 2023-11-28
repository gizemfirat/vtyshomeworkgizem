using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.DataAccess;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.DataAccess.Concrete.Mock
{
    internal class MockEmployeeDal : IEntityRepository<Employee>
    {
        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Employee? Get(Expression<Func<Employee, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetList(Expression<Func<Employee, bool>>? filter = null)
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id= 1, 
                    Name="Emrecan", 
                    Surname="Tuna"
                },
                                new Employee()
                {
                    Id= 1,
                    Name="Gizem",
                    Surname="Fırat"
                }
            };
        }
    }
}
