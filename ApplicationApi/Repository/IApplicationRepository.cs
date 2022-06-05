using ApplicationApi.DTOs;
using ApplicationApi.Models;

namespace ApplicationApi.Repository
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetApplicationsAsync();
        Task<IEnumerable<Application>> GetApplicationsByCatergoryAndDateAsync(string categoryname, DateTime? fromDate, DateTime? toDate);
        Task<Application> GetApplicationByIdAsync(int id);

    }
}
