using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vtys.Core.DataAccess.Npgsql;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.ComplexTypes;

namespace Vtys.Homework.DataAccess.Concrete.Npgsql
{
    public class NpgsqlGetProjectSourcesQuery : NpgsqlQueryBase<ProjectSourcesDetail> ,IGetProjectSourcesQuery
    {
        public override List<ProjectSourcesDetail> Run(params object[] parameters)
        {
            return RunFunction("get_all_project_sourcess", parameters);
        }

        protected override ProjectSourcesDetail Map(NpgsqlDataReader reader)
        {
            return new ProjectSourcesDetail()
            {
                SourceName = reader.GetString(0),
                ProjectName = reader.GetString(1)
            };
        }
    }
}
