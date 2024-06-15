using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{

    public class Pedido
    {
        public int PedidoId { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Descricao { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
