using FluentValidation;
using QamarKitoblar.Service.Dtos.Categories;

namespace QamarKitoblar.Service.Validators.Geners;

public class GenerUpdateValidator : AbstractValidator<GenerUpdateDto>
{
    public GenerUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(15).WithMessage("Description field is required!");
    }
}
