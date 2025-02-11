using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SM_Horarios;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseInMemoryDatabase("InMemoryDb");

    public DbSet<Client> Client { get; set; } = null!;
    public DbSet<Firm> Firm { get; set; } = null!;
    public DbSet<Employee> Employee { get; set; } = null!;
    public DbSet<MarkedTime> MarkedTime { get; set; } = null!;
}
