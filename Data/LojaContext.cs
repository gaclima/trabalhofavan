using Microsoft.EntityFrameworkCore;
using Loja.Models;

public class LojaContext : DbContext
{
    public LojaContext(DbContextOptions<LojaContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; } = default!;
    public DbSet<Pedido> Pedido { get; set; } = default!;
    public DbSet<Produto> Produto { get; set; } = default!;
}
