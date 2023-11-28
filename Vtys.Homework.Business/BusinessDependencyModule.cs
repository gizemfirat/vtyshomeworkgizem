using Autofac;
using System.Reflection;
using Vtys.Homework.Business.Abstract;
using Vtys.Homework.Business.Concrete;
using Module = Autofac.Module;
using Vtys.Core.ExtensionMethods;

namespace Vtys.Homework.Business
{
    public class BusinessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();

            builder.Register(Assembly.GetExecutingAssembly());
        }
    }
}
