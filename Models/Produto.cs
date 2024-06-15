using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models
{

    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
}
}
