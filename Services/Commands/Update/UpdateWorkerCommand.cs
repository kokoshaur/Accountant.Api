using MediatR;
using Models;

namespace Services.Commands.Update
{
    public class UpdateWorkerCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string StructureUnit { get; set; }
        public uint Salary { get; set; }
        public POST Post { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime JoinToTeam { get; set; }
    }
}
