using AutoMapper;
using FriendlyExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetById
{
    internal class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, WorkerVm>
    {
        private readonly IWorkerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetWorkerByIdQueryHandler(IWorkerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkerVm> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            var worker = await _dbContext.Workers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (worker == null)
                throw new WorkerNotFoundException(request.Id);

            return _mapper.Map<WorkerVm>(worker);
        }
    }
}
