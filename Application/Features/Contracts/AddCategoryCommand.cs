namespace Application.Features.Contracts;
public class AddCategoryCommand
{
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? LastUpdatedAt { get; init; }
}
