using DomainApiFilmes.DesafioTecnico;
using FluentValidation;
using WebAPI.Utils;

namespace WebAPI.Validators
{
    public class FilmeValidator : AbstractValidator<FilmeDto>, IFilmeValidator
    {
        public FilmeValidator()
        {
            ValidarDadosDoFilme();
            ValidarDadosDeGenero();
        }

        public void ValidarDadosDeGenero()
        {
            RuleFor(x => x.GeneroDoFilme)
                .SetValidator(new GeneroValidator());
        }

        public void ValidarDadosDoFilme()
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