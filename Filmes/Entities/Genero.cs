using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Nome { get; set; }

        public DateTime? DataDeCriacao { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}