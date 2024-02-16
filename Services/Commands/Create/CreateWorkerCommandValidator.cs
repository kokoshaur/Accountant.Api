using FluentValidation;

namespace Services.Commands.Create
{
    internal class CreateWorkerCommandValidator : AbstractValidator<CreateWorkerCommand>
    {
        public CreateWorkerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Patronymic).NotEmpty().MaximumLength(200);

            RuleFor(x => x.StructureUnit).NotEmpty().MaximumLength(400);
            RuleFor(x => x.Post).NotEmpty();

            RuleFor(x => x.BirthDate).NotEmpty();
        }
    }
}
