using MediatR;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetById
{
    public class GetWorkerByIdQuery : IRequest<WorkerVm>
    {
        public Guid Id { get; set; }
    }
}
