using System.Transactions;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using ShooterLink.API.Configuration;

namespace ShooterLink.API.Data.Database;

public static class DatabaseInitializer
{
    public static void Initialize(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbOptions = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        try
        {
            using var transactionScope = new TransactionScope();
            using var connection = new NpgsqlConnection(dbOptions.ConnectionString);
            connection.Open();
            connection.Execute(InitScript);
            transactionScope.Complete();
        }
        catch (TransactionAbortedException ex)
        {
            Console.WriteLine("TransactionAbortedException Message: {0}", ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unhandled Exception Message: {0}", ex.Message);
        }
    }
    
    private const string InitScript = @"

        CREATE TABLE IF NOT EXISTS Users(
            Id uuid NOT NULL DEFAULT gen_random_uuid(),
            PasswordHash character varying(255) COLLATE pg_catalog.default NOT NULL,
            FirstName character varying(255) COLLATE pg_catalog.default NOT NULL,
            LastName character varying(255) COLLATE pg_catalog.default NOT NULL,
            Email character varying(255) COLLATE pg_catalog.default NOT NULL,
            NormalizedEmail character varying(255) COLLATE pg_catalog.default NOT NULL,
            EmailConfirmed boolean NOT NULL,
            NickName character varying(255) COLLATE pg_catalog.default,
            PhoneNumber character varying(20) COLLATE pg_catalog.default,
            DateOfBirth date,
            Verified boolean NOT NULL,
            Token character varying(255) COLLATE pg_catalog.default,
            Created timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
            CONSTRAINT Users_pkey PRIMARY KEY (Id));
            
        CREATE TABLE IF NOT EXISTS Roles(
            Id uuid NOT NULL DEFAULT gen_random_uuid(),
            Name character varying(20) COLLATE pg_catalog.default NOT NULL,
            CONSTRAINT Roles_pkey PRIMARY KEY (Id));
        
        CREATE TABLE IF NOT EXISTS Settings(
            Id uuid NOT NULL DEFAULT gen_random_uuid(),
            SettingName character varying(255) COLLATE pg_catalog.default NOT NULL,
            StringValue character varying(255) COLLATE pg_catalog.default,
            BoolValue boolean,
            IntValue integer,
            DoubleValue double precision,
            DateValue timestamp without time zone,
            Creator uuid NOT NULL,
            Modifier uuid NOT NULL,
            Created timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
            Modified timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
            CONSTRAINT Settings_pkey PRIMARY KEY (Id));
        
        CREATE TABLE IF NOT EXISTS UserRoles(
            UserId uuid NOT NULL,
            RoleId uuid NOT NULL,
            CONSTRAINT Roles_FK FOREIGN KEY (RoleId)
                REFERENCES public.Roles (Id) MATCH SIMPLE
                ON UPDATE NO ACTION
                ON DELETE CASCADE
                NOT VALID,
            CONSTRAINT Users_FK FOREIGN KEY (UserId)
                REFERENCES public.Users (Id) MATCH SIMPLE
                ON UPDATE NO ACTION
                ON DELETE CASCADE);
        ";
}
