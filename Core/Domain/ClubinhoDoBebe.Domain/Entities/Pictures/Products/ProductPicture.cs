using ClubinhoDoBebe.Domain.Entities.Products;

namespace ClubinhoDoBebe.Domain.Entities.Pictures.Products;

public class ProductPicture
{
    public ProductId productId { get; set; } = null!;
    public string Picture { get; set; } = null!;
}
