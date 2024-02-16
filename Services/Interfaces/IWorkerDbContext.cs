using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.Interfaces
{
    public interface IWorkerDbContext
    {
        DbSet<Worker> Workers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
