using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;

    public class LojaContext : DbContext
    {
        public LojaContext (DbContextOptions<LojaContext> options)
            : base(options)
        {
        }

        public DbSet<Loja.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<Loja.Models.Pedido> Pedido { get; set; } = default!;

public DbSet<Loja.Models.Produto> Produto { get; set; } = default!;
    }
