namespace Matchplanner.Shared.Models
{
    public record struct UserDto(Guid Id, string Name, bool IsActive);
}