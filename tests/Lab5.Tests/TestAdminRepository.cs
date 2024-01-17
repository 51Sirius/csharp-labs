using System.Collections.Generic;
using Abstractions.Repository;
using Models.Admins;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestAdminRepository : IAdminRepository
{
    private readonly IEnumerable<Admin> _admins;

    public TestAdminRepository(IEnumerable<Admin> admins)
    {
        _admins = admins;
    }

    public Admin? FindUserById(long adminId)
    {
        foreach (Admin user in _admins)
        {
            if (user.AdminId == adminId)
            {
                return user;
            }
        }

        return null;
    }
}