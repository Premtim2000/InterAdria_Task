using Core.Entities;

namespace Application.DTOs;
public class AddProductDto
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
