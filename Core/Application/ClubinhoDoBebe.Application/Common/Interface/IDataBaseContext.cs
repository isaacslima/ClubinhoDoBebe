using ClubinhoDoBebe.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ClubinhoDoBebe.Application.Common.Interface;

public interface IDataBaseContext
{
    DatabaseFacade Database { get; }

    DbSet<Product> Product { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
