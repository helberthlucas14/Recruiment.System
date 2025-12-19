using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruitment.System.Infra.Data.EF;

namespace Recruitment.System.Infra.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddAppConections(services, configuration);
            return services;
        }

        private static IServiceCollection AddAppConections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlDbRegistration(configuration);
            return services;
        }

        private static IServiceCollection AddSqlDbRegistration(
           this IServiceCollection services,
           IConfiguration configuration
        )
        {
            var connectionString = configuration
                .GetConnectionString("RSDb");
            ArgumentNullException.ThrowIfNull(connectionString);
            services.AddDbContext<RSContext>(
                options => options.UseSqlServer(
                    connectionString
                )
            );
            return services;
        }
    }

}

