using Abstractions.Repository;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Admins;
using Models.Users;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Admin? FindUserById(long adminId)
    {
        const string sql = """
                           select ad.admin_id, ad.password, us.user_id, us.user_name, us.user_role
                           from admins as ad
                           left join users as us
                           on ad.user_id = us.user_id
                           where admin_id = :adminId;
                           """;
#pragma warning disable CA2012
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter().GetResult();
#pragma warning restore CA2012

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("bill_id", adminId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;
        var user = new Admin(
            AdminId: reader.GetInt64(0),
            Id: reader.GetInt64(2),
            Username: reader.GetString(3),
            Role: reader.GetFieldValue<UserRole>(4));
        user.Password = reader.GetString(1);
        return user;
    }
}