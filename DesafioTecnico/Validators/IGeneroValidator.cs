using DomainApiFilmes.DesafioTecnico;
using FluentValidation;

namespace WebAPI.Validators
{
    public interface IGeneroValidator : IValidator<GeneroDto>
    {
        void ValidarDadosDeGenero();
    }
}