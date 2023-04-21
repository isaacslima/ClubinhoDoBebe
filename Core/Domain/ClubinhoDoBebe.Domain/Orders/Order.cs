using ClubinhoDoBebe.Domain.Customers;
using ClubinhoDoBebe.Domain.Products;

namespace ClubinhoDoBebe.Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private Order()
    { 
    }

    public OrderId Id { get; private set; }

    public CustomerId CustomerId { get; private set; }

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
