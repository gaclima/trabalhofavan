using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Nome { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
