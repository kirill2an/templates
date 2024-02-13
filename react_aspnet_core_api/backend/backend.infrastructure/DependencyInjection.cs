using backend.app.Interfaces.Repositories;
using backend.infrastructure.Data;
using backend.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace backend.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            string connString)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                // options.UseNpgsql(connString, f => f.MigrationsAssembly("backend.api"));
                options.UseNpgsql(connString, f => f.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
            //dotnet ef migrations add Init --startup-project ../backend.api/backend.api.csproj
            //dotnet ef database drop --startup-project ../backend.api/backend.api.csproj
        }
    }
}