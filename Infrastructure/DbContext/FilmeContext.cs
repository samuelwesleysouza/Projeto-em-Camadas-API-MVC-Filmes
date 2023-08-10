
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
    }
     public DbSet<Filme> Filmes { get; set; }
}
