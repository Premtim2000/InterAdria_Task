namespace Application.Features.Contracts;
public class UpdateCategoryCommand
{
    public Guid Id { get; set; }
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public DateTime? LastUpdatedAt { get; init; }
}
