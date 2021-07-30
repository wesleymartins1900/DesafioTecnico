using DomainApiFilmes.DesafioTecnico;
using System.Linq;

namespace WebAPI.Filters
{
    public static class FilmeOrdemExtensions
    {
        public static IQueryable<FilmeDto> AplicaOrdenacao(this IQueryable<FilmeDto> query, FilmeOrdem ordem)
        {
            if ((ordem is not null) && (!string.IsNullOrEmpty(ordem.OrdenarPor)))
            {
                query = from p in query
                        orderby (ordem.OrdenarPor)
                        select p;
            }

            return query;
        }
    }

    public class FilmeOrdem
    {
        public string OrdenarPor { get; set; }
    }
}