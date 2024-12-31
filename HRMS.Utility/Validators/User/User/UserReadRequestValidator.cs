﻿using FluentValidation;
using HRMS.Dtos.User.User.UserRequestDtos;

namespace HRMS.Utility.Validators.User.User
{
    public class UserReadRequestValidator : AbstractValidator<UserReadRequestDto>
    {
        public UserReadRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("User ID is Required.")
                .GreaterThan(0).WithMessage("User ID must be greater than Zero.");
        }
    }
}