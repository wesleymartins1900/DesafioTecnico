using Data.Entities;
using Domain;
using FluentValidation;
using Services;

namespace DesafioTecnico.Validators
{
    public class FilmeValidator : AbstractValidator<FilmeDto>
    {
        public FilmeValidator()
        {
            ValidarDadosDoFilme();
            ValidarDadosDeGenero();
        }

        private void ValidarDadosDeGenero()
        {
            RuleFor(x => x.GeneroDoFilme)
                .SetValidator(new GeneroValidator());
        }

        private void ValidarDadosDoFilme()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(ErrorMessages.CampoVazioOuInvalido)
                .MaximumLength(200)
                .WithMessage(ErrorMessages.CampoComCaracteresAcimaDoPermitido200);

            RuleFor(x => x.Ativo)
                .NotEmpty()
                .WithMessage(ErrorMessages.CampoVazioOuInvalido);
        }
    }
}