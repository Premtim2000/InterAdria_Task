namespace Application.Responses;
public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? LastUpdatedAt { get; init; }
}
