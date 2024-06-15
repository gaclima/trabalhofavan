using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{

    public class Produto
    {
        public int ProdutoId { get; set; }
        
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Nome { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1,50000)]
        public decimal Preco { get; set; }
}
}
