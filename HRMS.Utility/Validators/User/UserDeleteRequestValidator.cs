using FluentValidation;
using HRMS.Dtos.User.UserRequestModels;

namespace HRMS.Utility.Validators.User
{
    public class UserDeleteRequestValidator : AbstractValidator<UserDeleteRequestDto>
    {
        public UserDeleteRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("User ID is Required.")
                .GreaterThan(0).WithMessage("User ID must be greater than Zero.");
        }
    }
}
