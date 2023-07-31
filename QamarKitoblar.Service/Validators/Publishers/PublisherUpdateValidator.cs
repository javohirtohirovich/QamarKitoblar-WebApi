using FluentValidation;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Publishers;

namespace QamarKitoblar.Service.Validators.Publishers;

public class PublisherUpdateValidator : AbstractValidator<PublisherUpdateDto>
{
    public PublisherUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().NotNull().WithMessage("Company name is required!")
           .MinimumLength(3).WithMessage("Company name must be more than 3 characters!")
           .MaximumLength(50).WithMessage("Company name must be less than 50 characters!");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(15).WithMessage("Description field is required!");

        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("Company phone number is required!")
            .Must(phone => PhoneNumberValidator.IsValid(phone)).WithMessage("Phone number is incorrect!");

        When(dto => dto.ImagePath is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.ImagePath.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.ImagePath.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
