using FluentValidation;
using Vtys.Core.Constants;

namespace Vtys.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class FvValidator<T> : AbstractValidator<T>, IVtysValidator
    {
        void IVtysValidator.Validate(object instance)
        {
            if (typeof(T).IsAssignableFrom(instance.GetType()))
            {
                var result = Validate((T)instance);

                if (result.Errors.Count > 0)
                {
                    throw new Exception(string.Join(" ", result.Errors.Select(x => x.ErrorMessage).ToList()));
                }
            }
            else
            {
                throw new Exception(Messages.WRONG_VALIDATOR_TYPE);
            }
        }
    }
}
