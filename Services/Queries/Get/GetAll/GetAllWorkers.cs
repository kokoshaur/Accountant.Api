using MediatR;
using Services.Queries.Get.Models;

namespace Services.Queries.Get.GetAll
{
    public class GetAllWorkers : IRequest<List<WorkerVm>>
    {

    }
}
