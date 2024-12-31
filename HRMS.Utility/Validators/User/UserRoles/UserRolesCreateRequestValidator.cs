using FluentValidation;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.User.Roles
{
    public class UserRolesCreateRequestValidator : AbstractValidator<UserRolesCreateRequestDto>
    {
        public UserRolesCreateRequestValidator() 
        {
        
            RuleFor(roles=>roles.RoleName)
            .NotEmpty().WithMessage("RoleName Is Required")
            .Length(0, 100).WithMessage("RoleName must be between 0 and 100 characters.");

            RuleFor(roles => roles.PermissionGroupId)
              .NotNull().WithMessage("PermissionGroupId is Required.")
              .GreaterThan(0).WithMessage("Permission Group Id must be greater than Zero.");

            RuleFor(roles => roles.CreatedBy)
              .NotNull().WithMessage("CreatedBy is Required.")
              .GreaterThan(0).WithMessage("Created By must be greater than Zero.");

            RuleFor(roles => roles.IsActive)
               .NotNull().WithMessage("IsActive must be true or false.");

          

        }
    }
}
