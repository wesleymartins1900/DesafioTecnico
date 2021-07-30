using DomainApiFilmes.DesafioTecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers;

namespace WebAPI.Filters
{
    public class FilmePaginacao
    {
        public readonly int _tamanhoPadrao = 50;
        private int _pagina = 0;
        private int _tamanho = 0;

        public int Pagina
        {
            get
            {
                return (_pagina <= 0) ? 1 : _pagina;
            }
            set
            {
                _pagina = value;
            }
        }

        public int Tamanho
        {
            get
            {
                return (_tamanho <= 0) ? _tamanhoPadrao : _tamanho;
            }
            set
            {
                _tamanho = value;
            }
        }

        public int QtdeParaDescartar => Pagina > 0 ? Tamanho * (Pagina - 1) : Tamanho;
    }

    public class FilmePaginado
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public IList<FilmeDto> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }

        public static FilmePaginado From(FilmePaginacao parametros, IQueryable<FilmeDto> origem)
        {
            if (parametros is null) parametros = new FilmePaginacao();

            var totalItens = origem.Count();
            var totalPaginas = (int)Math.Ceiling(totalItens / (double)parametros.Tamanho);
            var temPaginaAnterior = (parametros.Pagina > 1);
            var temProximaPagina = (parametros.Pagina < totalPaginas);

            return new FilmePaginado
            {
                Total = totalItens,
                TotalPaginas = totalPaginas,
                TamanhoPagina = parametros.Tamanho,
                NumeroPagina = parametros.Pagina,
                Resultado = origem.Skip(parametros.QtdeParaDescartar).Take(parametros.Tamanho).ToList(),
                Anterior = temPaginaAnterior
                    ? $"{typeof(FilmeController)}?pagina={parametros.Pagina - 1}&tamanho={parametros.Tamanho}"
                    : "",
                Proximo = temProximaPagina
                    ? $"{typeof(FilmeController)}?pagina={parametros.Pagina + 1}&tamanho={parametros.Tamanho}"
                    : ""
            };
        }
    }
}