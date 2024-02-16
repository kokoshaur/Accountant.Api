using MediatR;
using Models;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Commands.Create
{
    internal class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand>
    {
        private readonly IWorkerDbContext _dbContext;

        public CreateWorkerCommandHandler(IWorkerDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = new Worker
            {
                Id = Guid.NewGuid(),

                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,

                StructureUnit = request.StructureUnit,
                Salary = request.Post.ToSalary(),
                Post = request.Post,

                BirthDate = request.BirthDate,
                JoinToTeam = DateTime.Now
            };

            await _dbContext.Workers.AddAsync(worker);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
