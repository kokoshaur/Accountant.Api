using MediatR;
using Models;

namespace Services.Commands.Create
{
    public class CreateWorkerCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string StructureUnit { get; set; }
        public POST Post { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
