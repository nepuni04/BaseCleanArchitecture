namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Email { get; }
        string DisplayName { get; }
    }
}
