﻿using FluentValidation;
using Framework.Core.Application.Messages;

namespace Blog.Module.Application.Commands.CategoryCommands.CreateCategory;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidation()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(10).WithMessage(ValidationMessages.MinLength)
            .MaximumLength(300).WithMessage(ValidationMessages.MaxLength);


        RuleFor(c => c.Icon)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(5).WithMessage(ValidationMessages.MinLength)
            .MaximumLength(1000).WithMessage(ValidationMessages.MaxLength);
    }
}