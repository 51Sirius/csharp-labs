using Abstractions.Repository;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Bill;
using Npgsql;

namespace Infrastructure.DataAccess.Repositories;

public class BillRepository : IBillRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BillRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Bill? FindBillById(long billId)
    {
        const string sql = """
                           select bill_id, pin_code, balance, user_id
                           from bill
                           where bill_id = :billId;
                           """;
#pragma warning disable CA2012
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter().GetResult();
#pragma warning restore CA2012

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("bill_id", billId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;
        var newBill = new Bill(
            Id: reader.GetInt64(0),
            Pin: reader.GetString(1),
            UserId: reader.GetInt64(3));
        newBill.Balance = reader.GetFloat(2);
        return newBill;
    }
}