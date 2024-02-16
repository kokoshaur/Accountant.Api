using FluentValidation;

namespace Services.Commands.Delete
{
    internal class DeleteWorkerCommandValidator : AbstractValidator<DeleteWorkerCommand>
    {
        public DeleteWorkerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
