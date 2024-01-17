using Itmo.Dev.Platform.Postgres.Plugins;
using Models.Users;
using Npgsql;

namespace Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));
        builder.MapEnum<UserRole>();
    }
}