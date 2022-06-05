using System.Data;
using System.Globalization;
using ApplicationApi.Data;
using ApplicationApi.Models;
using Dapper;

namespace ApplicationApi.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IDbContext _context;

        public ApplicationRepository(IDbContext context)
        {
            _context = context;
        }


        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            string query = "SELECT * FROM Application WHERE Id = @id";

			using (var connection = _context.StartConnection())
			{
				var application = await connection.QuerySingleOrDefaultAsync<Application>(query, new{ id});
				return application;
			}
        }

        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            string query = "SELECT * FROM Application";

			using (var connection = _context.StartConnection())
			{
				var applications = await connection.QueryAsync<Application>(query);
				return applications.ToList();
			}
        }

        public async Task<IEnumerable<Application>> GetApplicationsByCatergoryAndDateAsync(string categoryname, DateTime? fromDate, DateTime? toDate)
        {
            string query = String.Empty;
            var parameters = new DynamicParameters();
            // this action can be set as a trigger in another type of Db. or on a larger application a utility class can be set and inject to the repo
            categoryname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoryname.ToLower());

            if( toDate == null && fromDate == null)
            {
                query = "SELECT * FROM Application WHERE BusinessCategory = @BusinessCategory";

            }else{

                query = "SELECT * FROM Application WHERE (DateTimeUpdated BETWEEN @fromDate AND @toDate) AND BusinessCategory = @BusinessCategory";
                parameters.Add("@toDate", toDate, DbType.DateTime);
                parameters.Add("@fromDate", fromDate, DbType.DateTime);
            }
                parameters.Add("@BusinessCategory", categoryname, DbType.String);

            using (var connection = _context.StartConnection())
            {
                var applications = await connection.QueryAsync<Application>(query, parameters);

                return applications.ToList();
            }
        }

    }
}
