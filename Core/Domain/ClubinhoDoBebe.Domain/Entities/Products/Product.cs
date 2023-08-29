using ClubinhoDoBebe.Domain.Entities.Pictures.Products;

namespace ClubinhoDoBebe.Domain.Entities.Products;

public class Product : BaseClass
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public string Code { get; private set; } = string.Empty;

    public Product(string name, decimal price, string code)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Code = code;
    }
}