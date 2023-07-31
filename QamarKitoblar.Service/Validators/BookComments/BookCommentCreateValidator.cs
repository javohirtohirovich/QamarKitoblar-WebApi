﻿using FluentValidation;
using QamarKitoblar.Service.Dtos.BookComments;
using QamarKitoblar.Service.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Validators.BookComments;

public class BookCommentCreateValidator : AbstractValidator<BookCommentCreateDto>
{
    public BookCommentCreateValidator()
    {
        RuleFor(dto => dto.Comment).NotNull().NotEmpty().WithMessage("Comment field is required!")
            .MinimumLength(3).WithMessage("Comment must be more than 5 characters")
            .MaximumLength(50).WithMessage("Comment must be less than 70 characters");

    }
}
