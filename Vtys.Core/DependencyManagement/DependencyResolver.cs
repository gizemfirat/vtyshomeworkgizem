using Microsoft.Extensions.DependencyInjection;

namespace Vtys.Core.DependencyManagement
{
    public class DependencyResolver
    {
        private static IServiceProvider? _serviceProvider;
        private static IServiceCollection _services;

        public static void BuildServiceProvider(IServiceCollection services)
        {
            _services = services;
            _serviceProvider = services.BuildServiceProvider();
        }

        public static T Get<T>()
        {
            if (_serviceProvider != null)
                return _serviceProvider.GetService<T>();
            else return default;
        }

        public static object Get(Type type)
        {
            if (_serviceProvider != null)
                return _serviceProvider.GetService(type);
            else return default;
        }

        public static void AddScoped<T>(T item) where T : class, new()
        {
            _services.AddScoped(x => item);
            _serviceProvider = _services.BuildServiceProvider();
        }
    }
}
