using DomainApiFilmes.DesafioTecnico;
using Microsoft.Extensions.Configuration;
using MVC;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Services
{
    public class FilmeApiServices : BaseHttpService, IFilmeApiServices
    {
        public static class FilmeRequest
        {
            public const short TamanhoDasPaginasPadraoParaGet = 50;

            public static string GetAll => "api/filme/ListarFilmesCadastradosAsync";
            public static string GetById => "api/filme/ListarFilmeCadastradoPorIdAsync";
            public static string Add => "api/filme/CadastrarNovoFilmeAsync";
            public static string Update => "api/filme/AlterarFilmeCadastradoAsync";
            public static string Remove => "api/filme/RemoverFilmesAsync";
        }

        public override string Scope => "Filme.API";

        public FilmeApiServices(IConfiguration configuration,
                                HttpClient httpClient,
                                ISessionHelper sessionHelper)
            : base(configuration, httpClient, sessionHelper)
        {
            _baseUri = _configuration["MSFilmesUri"];
        }

        public async Task<FilmeDto> GetAllAsync(FilmeFiltro filtro, FilmeOrdem ordem, FilmePaginacao paginacao)
        {
            var param = new
            {
                FilmeFiltro = filtro,
                FilmeOrdem = ordem,
                FilmePaginacao = paginacao
            };

            return await GetAuthenticatedAsync<FilmeDto>(FilmeRequest.GetAll, param);
        }

        public async Task<FilmeDto> GetByIdAsync(int id) => await GetAuthenticatedAsync<FilmeDto>(FilmeRequest.GetById, new { Id = id });

        public async Task AddAsync(FilmeDto filmeDto) => await PostAsync<FilmeDto>(FilmeRequest.Add, filmeDto);

        public async Task UpdateAsync(FilmeDto filmeDto) => await PutAsync<FilmeDto>(FilmeRequest.Update, filmeDto);

        public async Task RemoveAsync(params FilmeDto[] filmeDto) => await PostAsync<FilmeDto>(FilmeRequest.Remove, filmeDto);
    }
}