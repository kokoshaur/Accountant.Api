using MediatR;

namespace Services.Commands.Delete
{
    public class DeleteWorkerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
