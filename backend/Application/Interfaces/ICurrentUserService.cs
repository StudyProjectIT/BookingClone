namespace Application.Interfaces;

public interface ICurrentUserService
{
    long? GetUserId();
    bool IsInRole(string role);
}
