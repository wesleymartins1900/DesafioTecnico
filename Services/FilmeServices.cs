using Data.Entities;
using Data.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class FilmeServices
    {
        public readonly BaseRepository<Filme> _repositorio;

        public FilmeServices(BaseRepository<Filme> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Filme[]> ListarFilmeCadastradoPorIdAsync(int id) => await _repositorio.SelectByIdAsync(id);

        public async Task<Filme[]> ListarFilmesCadastradosAsync() => await _repositorio.AllAsync();

        public async Task<Filme[]> RemoverFilmesAsync(params Filme[] filmes)
        {
            // Seleciona os ids dos filmes
            var idsApi = filmes.Select(x => x.Id).ToArray();

            // Verifica e captura Ids do DTO da API que não estejam cadastrados no DB
            var idsFilmesEncontrados = (await _repositorio.SelectByIdAsync(idsApi))
                                                          .Select(x => x.Id);

            // Captura os filmes que estão cadastrados e prontos para serem removidos
            var filmesParaRemover = filmes.Where(x => idsFilmesEncontrados.Contains(x.Id)).ToArray();

            // Remove do DB através do repositório
            await _repositorio.DeleteAsync(filmesParaRemover);

            return filmesParaRemover;
        }

        public async Task<Filme> CadastrarNovoFilmeAsync(Filme filme)
        {
            await _repositorio.SaveAsync(filme);

            return filme;
        }

        public async Task<Filme> AlterarFilmeCadastradoAsync(Filme novoFilme)
        {
            var filme = await ListarFilmeCadastradoPorIdAsync(novoFilme.Id);
            if (filme is null) return null;

            await _repositorio.AlterAsync(filme);

            return novoFilme;
        }
    }
}