using ClubinhoDoBebe.Domain.Entities.Products;

namespace ClubinhoDoBebe.Domain.Entities.Pictures.Products;

public class ProductPicture
{
    public Guid productId { get; set; }
    public string Picture { get; set; } = null!;
}
