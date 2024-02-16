using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Queries.Get.Models;

namespace Accountant.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ScriptsController : BaseController
    {
        private readonly IWorkerDbContext _dbContext;
        private readonly IMapper _mapper;
        public ScriptsController(IWorkerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WorkerVm>> GetAll()
            => Ok(_mapper.Map<List<WorkerVm>>(
                await _dbContext.Workers.FromSqlRaw("SELECT * FROM Workers").ToListAsync()));

        [HttpGet("/more100000")]
        public async Task<ActionResult<WorkerVm>> GetAllMore()
            => Ok(_mapper.Map<List<WorkerVm>>(
                await _dbContext.Workers.FromSqlRaw("SELECT * FROM Workers WHERE Salary > 100000").ToListAsync()));

        [HttpDelete("/more70")]
        public async Task<IActionResult> RemoveMore70()
        {
            await _dbContext.Workers.FromSql($"DELETE FROM Workers WHERE BirthDate < {DateTime.Now.AddYears(-70)}").ToListAsync();
            //Будет в ответе возвращаться ошибка
            //The required column 'Id' was not present in the results of a 'FromSql' operation.
            //Это нормально, удаление происходить всё равно будет,
            //просто майкрософт маленькая инди компания не могут поправить удаление
            return NoContent();
        }

        [HttpPost("/more150000")]
        public async Task<IActionResult> UpdateSalary()
        {
            await _dbContext.Workers.FromSqlRaw("UPDATE Workers SET Salary = 150000 WHERE Salary < 150000").ToListAsync();
            //Будет в ответе возвращаться ошибка
            //The required column 'Id' was not present in the results of a 'FromSql' operation.
            //Это нормально, изменение происходить всё равно будет,
            //просто майкрософт маленькая инди компания не могут поправить изменение
            return NoContent();
        }
    }
}
