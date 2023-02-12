using MappingSamples.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MappingSamples.DataAccessLayer;

public class DataContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinimalDB-TPC;Integrated Security=True;")
            .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }).EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>();
        modelBuilder.Entity<Worker>();

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(false);

        base.ConfigureConventions(configurationBuilder);
    }
}
