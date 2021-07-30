using DomainApiFilmes.DesafioTecnico;
using FluentValidation;

namespace WebAPI.Validators
{
    public interface ILocacaoValidator : IValidator<LocacaoDto>
    {
        void ValidarDadosDeFilmes();

        void ValidarDadosDeLocacao();
    }
}