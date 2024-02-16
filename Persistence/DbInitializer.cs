namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(WorkerDbContext context) => context.Database.EnsureCreated();
    }
}
