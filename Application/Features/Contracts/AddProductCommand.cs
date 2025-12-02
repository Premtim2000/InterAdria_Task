using Core.Entities;

namespace Application.Features.Contracts;
public class AddProductCommand
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
}
