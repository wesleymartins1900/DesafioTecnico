using DomainApiFilmes.DesafioTecnico;
using FluentValidation;
using WebAPI.Utils;

namespace WebAPI.Validators
{
    public class LocacaoValidator : AbstractValidator<LocacaoDto>, ILocacaoValidator
    {
        public LocacaoValidator()
        {
            ValidarDadosDeLocacao();
            ValidarDadosDeFilmes();
        }

        public void ValidarDadosDeFilmes()
        {
            RuleForEach(x => x.ListaDeFilmes)
                .SetValidator(new FilmeValidator());
        }

        public void ValidarDadosDeLocacao()
        {
            RuleFor(x => x.CpfDoCliente)
               .NotEmpty()
               .WithMessage(ErrorMessages.CampoVazioOuInvalido)
               .MaximumLength(14)
               .WithMessage(ErrorMessages.CampoComCaracteresAcimaDoPermitido14);

            RuleFor(x => x.DataDeLocacao)
                .NotEmpty()
                .WithMessage(ErrorMessages.CampoVazioOuInvalido);
        }
    }
}