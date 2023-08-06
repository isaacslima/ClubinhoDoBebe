using ClubinhoDoBebe.Domain.Entities.Pictures.Products;

namespace ClubinhoDoBebe.Domain.Entities.Products;

public class Product
{
    public ProductId Id { get; private set; } = null!;

    public string Name { get; private set; } = string.Empty;

    public Money Price { get; private set; } = null!;

    public Sku? Sku { get; private set; }

    public Product(string name, Money price, Sku? sku)
    {
        Id = new ProductId(Guid.NewGuid());
        Name = name;
        Price = price;
        Sku = sku;
    }
}