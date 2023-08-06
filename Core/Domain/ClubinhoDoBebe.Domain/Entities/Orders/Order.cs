using ClubinhoDoBebe.Domain.Entities.Customers;
using ClubinhoDoBebe.Domain.Entities.Products;

namespace ClubinhoDoBebe.Domain.Entities.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    public OrderId Id { get; private set; } = null!;

    public CustomerId CustomerId { get; private set; } = null!;

    public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };

        return order;
    }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(
            new LineItemId(Guid.NewGuid()),
            Id,
            productId,
            price);

        _lineItems.Add(lineItem);
    }
}
