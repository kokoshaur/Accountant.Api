using FluentValidation;

namespace Services.Commands.Update
{
    internal class UpdateWorkerCommandValidator : AbstractValidator<UpdateWorkerCommand>
    {
        public UpdateWorkerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual(Guid.Empty);

            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Patronymic).NotEmpty().MaximumLength(200);

            RuleFor(x => x.StructureUnit).NotEmpty().MaximumLength(400);
            RuleFor(x => x.Salary).NotEmpty();
            RuleFor(x => x.Post).NotEmpty();

            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.JoinToTeam).NotEmpty();
        }
    }
}
