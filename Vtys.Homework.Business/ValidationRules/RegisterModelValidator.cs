using FluentValidation;
using Vtys.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Vtys.Homework.Business.Constants;
using Vtys.Homework.Business.Models;

namespace Vtys.Homework.Business.ValidationRules
{
    public class RegisterModelValidator : FvValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage(Messages.EMAIL_FORMAT_NOT_CORRECT);
            RuleFor(x => x.Password == x.PasswordAgain).Equal(true).WithMessage(Messages.PASSWORDS_NOT_MATCH);
        }
    }
}
