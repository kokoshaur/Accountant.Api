using Persistence;

namespace Accountant.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHost(args);

            using(var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    DbInitializer.Initialize(serviceProvider.GetRequiredService<WorkerDbContext>());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            host.Run();
        }

        public static IHost CreateHost(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build();
    }
}
