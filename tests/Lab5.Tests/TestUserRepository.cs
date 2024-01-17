using System.Collections.Generic;
using Abstractions.Repository;
using Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestUserRepository : IUserRepository
{
    private readonly IEnumerable<User> _users;

    public TestUserRepository(IEnumerable<User> user)
    {
        _users = user;
    }

    public User? FindUserByUsername(string username)
    {
        foreach (User user in _users)
        {
            if (user.Username == username)
            {
                return user;
            }
        }

        return null;
    }
}