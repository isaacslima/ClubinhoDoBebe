using ClubinhoDoBebe.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubinhoDoBebe.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            customerId => customerId.Value,
            value => new CustomerId(value));

        builder.Property(c => c.Name).HasMaxLength(255);

        builder.Property(c => c.Email).HasMaxLength(255);

        builder.Property(c => c.CellPhone).HasMaxLength(15);

        builder.HasIndex(c => c.CellPhone).IsUnique();
    }
}
