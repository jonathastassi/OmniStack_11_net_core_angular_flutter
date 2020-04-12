using backend.Models;
using FluentValidation;

namespace backend.Validations
{
    public class IncidentValidation : AbstractValidator<Incident>
    {
        public IncidentValidation()
        {
            RuleFor(x => x.Title).NotNull().Length(0, 100);
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Value).NotNull().GreaterThan(0);

            RuleFor(x => x)
                .NotNull()
                .WithMessage("Incidente não encontrado");
        }
    }
}