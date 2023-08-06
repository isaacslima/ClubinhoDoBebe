namespace ClubinhoDoBebe.Domain.Entities.Customers;

public class Customer
{
    public CustomerId Id { get; private set; } = null!;

    public string Email { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string CellPhone { get; private set; } = null!;
}
