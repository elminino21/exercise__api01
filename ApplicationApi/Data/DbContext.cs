using System.Data;
using Microsoft.Data.Sqlite;

namespace ApplicationApi.Data
{
    public class DbContext: IDbContext
    {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DataDb");
    }

    public IDbConnection StartConnection()
        => new SqliteConnection(_connectionString);
    }
}
