using Contracts;
using Models.Users;

namespace Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
    public bool IsAdmin { get; set; }
}