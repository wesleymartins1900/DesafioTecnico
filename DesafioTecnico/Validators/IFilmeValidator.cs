using DomainApiFilmes.DesafioTecnico;
using FluentValidation;

namespace WebAPI.Validators
{
    public interface IFilmeValidator : IValidator<FilmeDto>
    {
        void ValidarDadosDeGenero();

        void ValidarDadosDoFilme();
    }
}