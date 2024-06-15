using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{

    public class Pedido
    {
        public int PedidoId { get; set; }
        public string? Descricao { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
