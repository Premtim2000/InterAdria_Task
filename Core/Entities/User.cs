using BCrypt.Net;

namespace Core.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? LastUpdatedAt { get; init; }

    public static User CreateAdminUser()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Username = "admin",
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin", 13),
            Email = "admin@admin.com",
            CreatedAt = DateTime.UtcNow
        };
    }
}
