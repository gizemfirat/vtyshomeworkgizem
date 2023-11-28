using Castle.DynamicProxy;
using Vtys.Core.Interceptors;
using Vtys.Core.Results;

namespace Vtys.Core.Aspects
{
    public class ExceptionResultAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                invocation.ReturnValue = new ErrorResult(ex.Message, ex);
            }
        }
    }
}
