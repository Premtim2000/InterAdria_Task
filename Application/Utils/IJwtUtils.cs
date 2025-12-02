namespace Application.Utils;
public interface IJwtUtils
{
    string GenerateToken(string id, string role);
    string GenerateToken(string id);
}
