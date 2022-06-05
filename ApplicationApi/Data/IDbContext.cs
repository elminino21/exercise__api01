using System.Data;

namespace ApplicationApi.Data
{
    public interface IDbContext
    {
        IDbConnection StartConnection();
    }
}
