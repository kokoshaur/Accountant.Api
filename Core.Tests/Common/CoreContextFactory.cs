using Microsoft.EntityFrameworkCore;
using Models;
using Persistence;

namespace Core.Tests.Common
{
    internal class CoreContextFactory
    {
        public static WorkerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<WorkerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new WorkerDbContext(options);
            context.Database.EnsureCreated();
            context.Workers.AddRange(
                GetDefaultWorker(1, "3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                GetDefaultWorker(2, "848cfa3a-d7ba-4d4a-b9b7-e8b698d43c98"),
                GetDefaultWorker(3, "27775dd3-3df8-484e-9edd-3d21e4401f22"));

            context.SaveChanges();
            return context;

            Models.Worker GetDefaultWorker(int number, string guid)
                => new Models.Worker
                {
                    Id = Guid.Parse(guid),

                    Name = $"TestWorkerName{number}",
                    Surname = $"TestWorkerSurname{number}",
                    Patronymic = $"TestWorkerPatronymic{number}",

                    StructureUnit = $"TestStructureUnit{number}",
                    Post = POST.Jun,

                    BirthDate = DateTime.Now,
                    JoinToTeam = DateTime.Now
                };
        }

        public static void Destroy(WorkerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
