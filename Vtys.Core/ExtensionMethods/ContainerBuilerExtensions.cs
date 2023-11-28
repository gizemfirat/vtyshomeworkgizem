using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Reflection;
using Vtys.Core.Interceptors;

namespace Vtys.Core.ExtensionMethods
{
    public static class ContainerBuilerExtensions
    {
        public static void Register(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                   {
                       Selector = new AspectInterceptorSelector()
                   }).SingleInstance();
        }
    }
}
