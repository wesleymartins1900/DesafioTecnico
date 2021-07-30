using Data.Entities;
using System.Threading.Tasks;

namespace MSFilmes.Services
{
    public interface IFilmeServices
    {
        Task<Filme[]> ListarFilmeCadastradoPorIdAsync(int id);

        Task<Filme[]> ListarFilmesCadastradosAsync();

        Task<Filme[]> RemoverFilmesAsync(params Filme[] filmes);

        Task<Filme> CadastrarNovoFilmeAsync(Filme filme);

        Task<Filme> AlterarFilmeCadastradoAsync(Filme novoFilme);
    }
}