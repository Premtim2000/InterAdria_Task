using Core.Entities;

namespace Application.Responses;
public class ProductResponse
{
    public string Name { get; set; }
    public CategoryResponse Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
