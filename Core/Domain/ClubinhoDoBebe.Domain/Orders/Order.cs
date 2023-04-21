using ClubinhoDoBebe.Domain.Customers;
using ClubinhoDoBebe.Domain.Products;

namespace ClubinhoDoBebe.Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();

    private Order()
    { 
    }

    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id
        };

        return order;
    }

    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);

        _lineItems.Add(lineItem);
    }
}
