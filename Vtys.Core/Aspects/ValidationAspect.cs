using Castle.DynamicProxy;
using Vtys.Core.Constants;
using Vtys.Core.CrossCuttingConcerns.Validation;
using Vtys.Core.Interceptors;

namespace Vtys.Core.Aspects
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IVtysValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(Messages.WRONG_VALIDATOR_TYPE);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IVtysValidator?)Activator.CreateInstance(_validatorType);
            if (validator != null)
            {
                var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
                var entites = invocation.Arguments.Where(x => x.GetType() == entityType);

                foreach (var entity in entites)
                {
                    validator.Validate(entity);
                }
            }
        }

    }
}
