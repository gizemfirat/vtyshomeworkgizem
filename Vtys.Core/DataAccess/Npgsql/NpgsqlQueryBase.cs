using Npgsql;
using Vtys.Core.DependencyManagement;

namespace Vtys.Core.DataAccess.Npgsql
{
    public abstract class NpgsqlQueryBase<T> : IQuery<T> where T: class, new()
    {
        private readonly string _connectionString;

        public NpgsqlQueryBase()
        {
            var dbConnectionInfo = DependencyResolver.Get<DbConnectionInfo>();
            _connectionString = dbConnectionInfo.ToNpgsqlString();
        }

        public abstract List<T> Run(params object[] parameters);
        protected abstract T Map(NpgsqlDataReader reader);

        protected List<T> ExecuteQuery(string query) 
        {
            var result = new List<T>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(Map(reader));
            }
            return result;
        }

        protected List<T> RunFunction(string functionName, params object[] parameters)
        {
            var parameterList = parameters.Select(x => x.ToString()).ToList();
            var parametersString = string.Join(",", parameterList);
            var query = $"SELECT * FROM {functionName}({parametersString})";
            return ExecuteQuery(query);
        }
    }
}
