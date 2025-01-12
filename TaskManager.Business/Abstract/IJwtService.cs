namespace TaskManager.Business.Abstract;

public interface IJwtService
{
    public Task<string> GenerateToken(string userId, string username);
}