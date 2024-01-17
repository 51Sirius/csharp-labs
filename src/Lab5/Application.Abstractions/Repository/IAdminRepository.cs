using Models.Admins;

namespace Abstractions.Repository;

public interface IAdminRepository
{
    Admin? FindUserById(long adminId);
}