using Backend.Api.Interfaces.Repository;
using Backend.Api.Models;
using FluentValidation;

namespace Backend.Api.Validations
{
    public class OngValidation : AbstractValidator<Ong>
    {
        public OngValidation(
            IOngRepository ongRepository
        )
        {
            RuleFor(x => x.Name).NotNull().Length(0, 100);
            RuleFor(x => x.Email).NotNull().EmailAddress().Length(0, 100);
            RuleFor(x => x.Password).NotNull().Length(0, 30);
            RuleFor(x => x.Whatsapp).NotNull().Length(0, 30);
            RuleFor(x => x.City).NotNull().Length(0, 100);
            RuleFor(x => x.Uf).NotNull().Length(2);

            RuleFor(x => x)
                .MustAsync(async (ong, cancellation) =>
                {
                    Ong exists = await ongRepository.GetByEmail(ong.Email);

                    if (exists != null && ong.Id != exists.Id)
                    {
                        return false;
                    }
                    return true;
                }).WithName("Email").WithMessage("E-mail está em uso");
        }
    }
}