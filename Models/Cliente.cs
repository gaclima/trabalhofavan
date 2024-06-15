using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
