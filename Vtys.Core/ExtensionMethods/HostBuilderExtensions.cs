using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace Vtys.Core.ExtensionMethods
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseAutofacServiceProvider(this IHostBuilder builder, params Module[] modules)
        {
            return builder
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    foreach (var module in modules)
                        builder.RegisterModule(module);
                });
        }
    }
}
