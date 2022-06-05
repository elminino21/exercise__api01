
using ApplicationApi.Data;
using ApplicationApi.Repository;

namespace ApplicationApi.Extensions;
// abstract away dependency configuration
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services )
    {
        services.AddSingleton<IDbContext, DbContext>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return  services;
    }
}
