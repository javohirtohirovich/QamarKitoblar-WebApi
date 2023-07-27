﻿using FluentValidation;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Validators.Geners;

public class GenerCreateValidator : AbstractValidator<GenerCreateDto>
{
    public GenerCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(15).WithMessage("Description field is required!");
    }
}
