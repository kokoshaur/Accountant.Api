using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<WorkerDbContext>(options =>
                    {
                        options.UseSqlite(configuration["DbConnection"]);
                    })
                .AddScoped<IWorkerDbContext>(provider => 
                    provider.GetService<WorkerDbContext>());
    }
}
