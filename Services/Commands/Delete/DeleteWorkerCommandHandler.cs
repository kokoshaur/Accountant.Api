using FriendlyExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Commands.Delete
{
    internal class DeleteWorkerCommandHandler : IRequest<DeleteWorkerCommand>
    {
        private readonly IWorkerDbContext _dbContext;

        public DeleteWorkerCommandHandler(IWorkerDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = await _dbContext.Workers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (worker == null)
                throw new WorkerNotFoundException(request.Id);
            
            _dbContext.Workers.Remove(worker);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
