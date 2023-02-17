using System.ComponentModel.DataAnnotations;
using MappingSamples.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MappingSamples.DataAccessLayer;

public class DataContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinimalDB-TPC;Integrated Security=True;")
            .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }).EnableSensitiveDataLogging();

        optionsBuilder.AddInterceptors(new SampleInterceptor());

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>().HasDiscriminator<int>("Role")
        //    .HasValue<Student>(1)
        //    .HasValue<Worker>(2);

        modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        modelBuilder.Entity<Student>();
        modelBuilder.Entity<Worker>();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Validate();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(false);

        base.ConfigureConventions(configurationBuilder);
    }

    private void Validate()
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(e => e.Entity)
            .ToList();

        foreach (var entity in entities)
        {
            var validationContext = new ValidationContext(entity);
            Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
        }
    }
}
