using Data.Entities;
using Domain;
using FluentValidation;

namespace Services.Validators
{
    public class LocacaoValidator : AbstractValidator<LocacaoDto>
    {
        public LocacaoValidator()
        {
            ValidarDadosDeLocacao();
            ValidarDadosDeFilmes();
        }

        private void ValidarDadosDeFilmes()
        {
            RuleForEach(x => x.ListaDeFilmes)
                .SetValidator(new FilmeValidator());
        }

        private void ValidarDadosDeLocacao()
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