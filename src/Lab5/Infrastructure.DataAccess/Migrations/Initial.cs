using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'employee',
            'customer'
        );
        
        create type operation as enum
        (
            'send',
            'get',
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null
        );
        
        create table bills
        (
            bill_id bigint primary key generated always as identity ,
            pin_code text not null ,
            balance float not null ,
            user_id bigint not null
        );
        
        create table operations
        (
            operation_id bigint primary key generated always as identity ,
            operation operation not null ,
            bill_id bigint not null ,
            sum float not null
        );
        
        create table admins
        (
            admin_id bigint primary key generated always as identity ,
            password text not null
            user_id bigint not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop type user_role;
        drop table bills;
        """;
}