using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200), Required]
        public string Nome { get; set; }

        public DateTime? DataDeCriacao { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public int? GeneroId { get; set; }

        public virtual Genero GeneroDoFilme { get; set; }
    }
}