using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Commands.Create;
using Services.Commands.Delete;
using Services.Commands.Update;
using Services.Queries.Get.GetAll;
using Services.Queries.Get.GetById;
using Services.Queries.Get.GetByPageNumber;
using Services.Queries.Get.Models;

namespace Accountant.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WorkerController : BaseController
    {
        /// <summary>
        /// Возвращает всех работников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<WorkerVm>> GetAll()
            => Ok(await Mediator.Send(new GetAllWorkers()));

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerVm>> GetById([FromRoute] Guid id)
            => Ok(await Mediator.Send(new GetWorkerByIdQuery { Id = id }));

        [HttpGet("byPage")]
        public async Task<ActionResult<WorkerVm>> GetByPageNumber(
            [FromQuery(Name = "pageNumber")] uint number,
            [FromQuery(Name = "FilterByPost")] POST? filterPost,
            [FromQuery(Name = "SortedByName")] bool sortedByName = false)
            => Ok(await Mediator.Send(new GetListByPageNumberQuery 
            { 
                PageNumber = number, 
                FilterByPost = filterPost,
                SortedByName = sortedByName
            }));

        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerCommand worker)
        {
            await Mediator.Send(worker);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorker([FromBody] UpdateWorkerCommand worker)
        {
            await Mediator.Send(worker);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteWorker(Guid id)
        {
            await Mediator.Send(new DeleteWorkerCommand { Id = id });

            return NoContent();
        }
    }
}
