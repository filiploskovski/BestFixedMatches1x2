using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.CachingProvider;
using Shared.DbInit;
using Shared.DbInit.Repository;


namespace Shared
{
    public static class SharedServices
    {
        public static void AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.CachingConfiguration(configuration);
            services.DatabaseInitialization(configuration);
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}