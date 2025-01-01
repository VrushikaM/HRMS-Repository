using FluentValidation;
using HRMS.Dtos.User.UserRoles.UserRolesRequestDtos;

namespace HRMS.Utility.Validators.User.UserRoles
{
    public class UserRolesReadRequestValidator : AbstractValidator<UserRolesReadRequestDto>
    {
        public UserRolesReadRequestValidator()
        {
            RuleFor(roles => roles.RoleId)
              .NotNull().WithMessage("User Role Id is Required.")
              .GreaterThan(0).WithMessage("User Role Id must be greater than Zero.");
        }
    }
}
