using Models.Users;

namespace Models.Admins;

public record Admin(long AdminId, long Id, string Username, UserRole Role) : User(Id, Username, Role)
{
    public string? Password { get; set; }
}