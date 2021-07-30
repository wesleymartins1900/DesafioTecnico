using DomainApiFilmes.DesafioTecnico;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Services
{
    public interface IFilmeApiServices
    {
        Task<FilmeDto> GetAllAsync(FilmeFiltro filtro, FilmeOrdem ordem, FilmePaginacao paginacao);

        Task<FilmeDto> GetByIdAsync(int id);

        Task AddAsync(FilmeDto filmeDto);

        Task UpdateAsync(FilmeDto filmeDto);

        Task RemoveAsync(params FilmeDto[] filmeDto);
    }
}