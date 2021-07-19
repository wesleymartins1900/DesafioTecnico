using System;

namespace Domain
{
    public class FilmeDto : BaseDto
    {
        public string Nome { get; set; }
        public DateTime? DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
        public int? GeneroId { get; set; }
        public GeneroDto GeneroDoFilme { get; set; }
    }
}