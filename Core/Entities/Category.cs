namespace Core.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public DateTime CreatedAt { get; init; }
    public DateTime? LastUpdatedAt { get; init; }
}
