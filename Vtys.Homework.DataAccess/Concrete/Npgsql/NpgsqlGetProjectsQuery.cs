using Npgsql;
using Vtys.Core.DataAccess.Npgsql;
using Vtys.Core.ExtensionMethods;
using Vtys.Homework.DataAccess.Abstract.Queries;
using Vtys.Homework.Entities.ComplexTypes;

namespace Vtys.Homework.DataAccess.Concrete.Npgsql
{
    public class NpgsqlGetProjectsQuery : NpgsqlQueryBase<ProjectDetail>, IGetProjectsQuery
    {
        public override List<ProjectDetail> Run(params object[] parameters)
        {
            return RunFunction("get_projects", parameters);
        }

        protected override ProjectDetail Map(NpgsqlDataReader reader)
        {
            return new ProjectDetail()
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                StartDate = reader.GetDateTime(2),
                FinishDate = reader.GetDateTime(3),
                Tasks = reader.GetString(4).FromJson<List<TaskDetail>>()
            };
        }
    }
}
