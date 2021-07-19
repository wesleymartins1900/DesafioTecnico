using System;
using System.Collections.Generic;

namespace Domain
{
    public class LocacaoDto : BaseDto
    {
        public ICollection<FilmeDto> ListaDeFilmes { get; set; }
        public string CpfDoCliente { get; set; }
        public DateTime DataDeLocacao { get; set; }
    }
}