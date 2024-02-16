using MediatR;
using Models;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetByPageNumber
{
    public class GetListByPageNumberQuery : IRequest<List<WorkerVm>>
    {
        public uint PageNumber { get; set; }

        public POST? FilterByPost { get; set; }

        public bool SortedByName { get; set; }
    }
}
