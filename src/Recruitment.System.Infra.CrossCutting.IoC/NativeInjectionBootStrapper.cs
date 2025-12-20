using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruitment.System.Application.Interfaces;
using Recruitment.System.Application.UseCases.User.Common;
using Recruitment.System.Application.UseCases.User.EnsureUserUseCase;
using Recruitment.System.Domain.Repository;
using Recruitment.System.Infra.Data.EF;
using Recruitment.System.Infra.Data.EF.Repositories;
using Recruitment.System.Infra.Data.Redis;
using StackExchange.Redis;

namespace Recruitment.System.Infra.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterApplicationServices(services);
            AddAppConections(services, configuration);
            RegisterInfraService(services, configuration);
            return services;
        }

        public static IServiceCollection RegisterInfraService(
        IServiceCollection services,
        IConfiguration configuration)
        {
            AddAppConections(services, configuration);
            services.AddScoped<ICache, RedisCache>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddAppConections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlDbRegistration(configuration);
            services.AddRedisDbRegistration(configuration);
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

        private static IServiceCollection AddRedisDbRegistration(
          this IServiceCollection services,
         IConfiguration configuration
     )
        {
            var redisConnection = configuration.GetConnectionString("RedisDb");
            ArgumentNullException.ThrowIfNull(redisConnection);
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConnection));
            return services;
        }


        private static IServiceCollection RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<EnsureUserCommand, UserOutputModel>, EnsureUserCommandHandler>();
            return services;
        }
    }
}

