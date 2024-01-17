using Abstractions.Repository;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, user_role
                           from users
                           where user_name = :username;
                           """;
#pragma warning disable CA2012
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter().GetResult();
#pragma warning restore CA2012

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            Role: reader.GetFieldValue<UserRole>(2));
    }
}