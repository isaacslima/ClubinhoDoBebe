namespace ClubinhoDoBebe.Domain.Entities;

public class BaseClass
{
    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime? Updated { get; set; }
}
