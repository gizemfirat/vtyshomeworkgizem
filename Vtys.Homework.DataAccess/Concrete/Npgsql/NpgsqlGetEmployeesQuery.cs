using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.DataAccess.Npgsql;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.ComplexTypes;
using Vtys.Homework.Entities.Concrete;

namespace Vtys.Homework.DataAccess.Concrete.Npgsql
{
    public class NpgsqlGetEmployeesQuery : NpgsqlQueryBase<EmployeeDetail> ,IGetEmployeesQuery
    {
        public override List<EmployeeDetail> Run(params object[] parameters)
        {
           return RunFunction("get_employees", parameters);
        }

        protected override EmployeeDetail Map(NpgsqlDataReader reader)
        {
            return new EmployeeDetail()
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Surname = reader.GetString(2),
                DepartmentName = reader.GetString(3)
            };
        }
    }
}
