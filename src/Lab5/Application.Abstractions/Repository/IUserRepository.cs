using Models.Users;

namespace Abstractions.Repository;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}