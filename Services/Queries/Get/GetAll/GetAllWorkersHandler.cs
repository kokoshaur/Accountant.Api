using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetAll
{
    internal class GetAllWorkersHandler : IRequestHandler<GetAllWorkers, List<WorkerVm>>
    {
        private readonly IWorkerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllWorkersHandler(IWorkerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<WorkerVm>> Handle(GetAllWorkers request, CancellationToken cancellationToken)
            => _mapper.Map<List<WorkerVm>>(await _dbContext.Workers.ToListAsync());
    }
}
