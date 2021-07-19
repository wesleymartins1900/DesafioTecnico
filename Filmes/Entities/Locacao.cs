using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ICollection<Filme> ListaDeFilmes { get; set; }

        [StringLength(14), Required]
        public string CpfDoCliente { get; set; }

        [Required]
        public DateTime DataDeLocacao { get; set; }
    }
}