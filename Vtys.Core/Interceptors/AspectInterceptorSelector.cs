using Castle.DynamicProxy;
using System.Reflection;

namespace Vtys.Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBase>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBase>(true);
            classAttributes.AddRange(methodAttributes ?? new List<MethodInterceptionBase>());
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
