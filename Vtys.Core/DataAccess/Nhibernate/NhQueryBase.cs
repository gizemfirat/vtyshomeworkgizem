using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtys.Core.DataAccess.Nhibernate
{
    public class Member
    {
        public long id { get; set; }
    }

    public class MemberMap : ClassMap<Member>
    {
        public MemberMap()
        {
            Table("members");
            Map(x => x.id).Column("id");
        }
    }
    public abstract class NhQueryBase<T> : IQuery<T>
        where T : class, new()
    {
        public abstract T Run(object? args = null);

       // protected object ExecuteQuery(string query)
       // {
       //     var connectionString = "Server=localhost;Port=5432;Database=vtyshomework;User /Id=postgres;Password=123456;";
       //     var sessionFactory = Fluently.Configure()
       //         .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString))
       //         .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MemberMap>())
       //         .BuildSessionFactory();
       //
       //     //using (var session = sessionFactory.OpenSession())
       //     //{
       //     //    var result = session.CreateQuery(query).List<Member>();
       //     //    //var result = session.CreateQuery(query).List();
       //     //    return result;
       //     //}
       // }
    }
}
