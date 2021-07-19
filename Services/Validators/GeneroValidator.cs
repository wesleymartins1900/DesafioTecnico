using Data.Entities;
using Domain;
using FluentValidation;

namespace Services.Validators
{
    public class GeneroValidator : AbstractValidator<GeneroDto>
    {
        public GeneroValidator()
        {
            ValidarDadosDeGenero();
        }

        private void ValidarDadosDeGenero()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(ErrorMessages.CampoVazioOuInvalido)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.CampoComCaracteresAcimaDoPermitido100);

            RuleFor(x => x.Ativo)
                .NotEmpty()
                .WithMessage(ErrorMessages.CampoVazioOuInvalido);
        }
    }
}