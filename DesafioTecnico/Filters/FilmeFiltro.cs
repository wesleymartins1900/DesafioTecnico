using DomainApiFilmes.DesafioTecnico;
using System;
using System.Linq;

namespace WebAPI.Filters
{
    public static class FilmeFiltroExtensions
    {
        public static IQueryable<FilmeDto> AplicaFiltro(this IQueryable<FilmeDto> query, FilmeFiltro filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                {
                    query = query.Where(l => l.Nome.Contains(filtro.Nome));
                }

                if (filtro.DataDeCriacao is not null && filtro.TipoDataDeCriacao != default)
                {
                    switch (filtro.TipoDataDeCriacao)
                    {
                        case (short)FilmeFiltro.TipoDataDeCriacaoEnum.MaiorQue:
                            query =
                                query.Where(l => l.DataDeCriacao.Value > filtro.DataDeCriacao);
                            break;

                        case (short)FilmeFiltro.TipoDataDeCriacaoEnum.MenorQue:
                            query =
                               query.Where(l => l.DataDeCriacao.Value < filtro.DataDeCriacao);
                            break;

                        case (short)FilmeFiltro.TipoDataDeCriacaoEnum.IgualA:
                            query =
                               query.Where(l => l.DataDeCriacao.Value.Equals(filtro.DataDeCriacao));
                            break;
                    }
                }

                if (filtro.Ativo is not null)
                {
                    query = query.Where(l => l.Ativo.Equals(filtro.Ativo.Value));
                }

                if (filtro.GeneroDoFilme is not null)
                {
                    query = query.Where(l => l.GeneroDoFilme.Nome.Contains(filtro.GeneroDoFilme.Nome));
                }
            }
            return query;
        }
    }

    public class FilmeFiltro
    {
        public enum TipoDataDeCriacaoEnum : short
        {
            MaiorQue = 1,
            MenorQue = 2,
            IgualA = 3
        }

        public short? TipoDataDeCriacao { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDeCriacao { get; set; }
        public bool? Ativo { get; set; }
        public GeneroDto? GeneroDoFilme { get; set; }
    }
}