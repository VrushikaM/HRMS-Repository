using FluentValidation;
using HRMS.Dtos.User.UserRoles.UserRolesRequestDtos;

namespace HRMS.Utility.Validators.User.UserRoles
{
    public class UserRolesDeleteRequestValidator : AbstractValidator<UserRolesDeleteRequestDto>
    {
        public UserRolesDeleteRequestValidator()
        {

            RuleFor(roles => roles.RoleId)
               .NotNull().WithMessage("User Role Id is Required.")
               .GreaterThan(0).WithMessage("User Role Id must be greater than Zero.");
        }
    }
}
