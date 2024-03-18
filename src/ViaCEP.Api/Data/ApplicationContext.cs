using Microsoft.EntityFrameworkCore;

namespace ViaCEP.Api.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Endereco> Endereco { get; set; } = default!;
}