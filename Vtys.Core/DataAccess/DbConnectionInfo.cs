using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.DataAccess
{
    public  class DbConnectionInfo
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public string ToNpgsqlString()
        {
            return $"Host={Host}; Port={Port}; Username={Username}; Password={Password}; Database={Database}";
        }
    }
}
