using Models.Users;

namespace Contracts;

public interface ICurrentUserService
{
    User? User { get; }
    bool IsAdmin { get; set; }
}