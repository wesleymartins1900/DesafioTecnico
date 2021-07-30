using DomainApiFilmes.DesafioTecnico;
using FluentValidation;
using WebAPI.Utils;

namespace WebAPI.Validators
{
    public class GeneroValidator : AbstractValidator<GeneroDto>, IGeneroValidator
    {
        public GeneroValidator()
        {
            ValidarDadosDeGenero();
        }

        public void ValidarDadosDeGenero()
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