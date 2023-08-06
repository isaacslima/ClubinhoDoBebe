using ClubinhoDoBebe.Application.Common.Interface;
using ClubinhoDoBebe.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace ClubinhoDoBebe.Infrastructure.Data;

public class DataBaseContext : DbContext, IDataBaseContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
    }
}
