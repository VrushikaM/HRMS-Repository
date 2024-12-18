﻿using FluentValidation;
using HRMS.Dtos.User.UserRequestModels;

namespace HRMS.Utility.Validators.User
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequestDto>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.UserId)
               .NotNull().WithMessage("User ID is Required.")
               .GreaterThan(0).WithMessage("User ID must be greater than Zero.");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First Name is Required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last Name is Required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is Required.")
                .EmailAddress().WithMessage("Invalid Email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is Required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");
        }
    }
}
