using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetByPageNumber
{
    internal class GetListByPageNumberQueryHandler : IRequestHandler<GetListByPageNumberQuery, List<WorkerVm>>
    {
        private const int PageSize = 10;

        private readonly IWorkerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListByPageNumberQueryHandler(IWorkerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<WorkerVm>> Handle(GetListByPageNumberQuery request, CancellationToken cancellationToken)
        {
            if (request.FilterByPost == null && !request.SortedByName)
                return await GetWithoutFilter(request, cancellationToken);
            if (request.FilterByPost == null && request.SortedByName)
                return await GetSortedBySalary(request, cancellationToken);
            if (request.FilterByPost != null && !request.SortedByName)
                return await GetFilterByPost(request, cancellationToken);
            
            return await GetWithFilter(request, cancellationToken);
        }

        private async Task<List<WorkerVm>> GetWithoutFilter(GetListByPageNumberQuery request, CancellationToken cancellationToken)
            => await _dbContext.Workers
                .Skip((int)request.PageNumber * PageSize)
                .Take(PageSize)
                .ProjectTo<WorkerVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        private async Task<List<WorkerVm>> GetSortedBySalary(GetListByPageNumberQuery request, CancellationToken cancellationToken)
            => await _dbContext.Workers
                .OrderBy(p => p.Name)
                .Skip((int)request.PageNumber * PageSize)
                .Take(PageSize)
                .ProjectTo<WorkerVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        private async Task<List<WorkerVm>> GetFilterByPost(GetListByPageNumberQuery request, CancellationToken cancellationToken)
            => await _dbContext.Workers
                .Where(x => x.Post == request.FilterByPost)
                .Skip((int)request.PageNumber * PageSize)
                .Take(PageSize)
                .ProjectTo<WorkerVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        private async Task<List<WorkerVm>> GetWithFilter(GetListByPageNumberQuery request, CancellationToken cancellationToken)
            => await _dbContext.Workers
                .Where(x => x.Post == request.FilterByPost)
                .OrderBy(p => p.Name)
                .Skip((int)request.PageNumber * PageSize)
                .Take(PageSize)
                .ProjectTo<WorkerVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    }
}
