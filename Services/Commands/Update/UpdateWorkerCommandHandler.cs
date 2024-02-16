using FriendlyExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Commands.Update
{
    internal class UpdateWorkerCommandHandler : IRequest<UpdateWorkerCommand>
    {
        private readonly IWorkerDbContext _dbContext;

        public UpdateWorkerCommandHandler(IWorkerDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = await _dbContext.Workers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (worker == null)
                throw new WorkerNotFoundException(request.Id);

            worker.Name = request.Name;
            worker.Surname = request.Surname;
            worker.Patronymic = request.Patronymic;

            worker.StructureUnit = request.StructureUnit;
            worker.Salary = request.Salary;
            worker.Post = request.Post;

            worker.BirthDate = request.BirthDate;
            worker.JoinToTeam = request.JoinToTeam;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
