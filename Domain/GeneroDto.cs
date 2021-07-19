using System;

namespace Domain
{
    public class GeneroDto : BaseDto
    {
        public string Nome { get; set; }
        public DateTime? DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}