using Dapper;
using Microsoft.Data.SqlClient;

namespace ShooterLink.API.Data.Database;

public class DatabaseInitializer(string connectionString)
{
    public void Initialize()
    {
        using var connection = new SqlConnection(connectionString);

        const string createTablesScript = @"";

        connection.Execute(createTablesScript);
    }
}