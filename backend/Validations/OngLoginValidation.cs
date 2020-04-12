using backend.Dtos;
using FluentValidation;

namespace backend.Validations
{
    public class OngLoginValidation : AbstractValidator<OngLogin>
    {
        public OngLoginValidation()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress().Length(0, 100);
            RuleFor(x => x.Password).NotNull().Length(0, 30);
        }
    }
}