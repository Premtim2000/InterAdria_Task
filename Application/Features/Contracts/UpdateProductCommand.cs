namespace Application.Features.Contracts;
public class UpdateProductCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
