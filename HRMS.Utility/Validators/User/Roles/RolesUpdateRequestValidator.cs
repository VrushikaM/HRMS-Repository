using FluentValidation;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.User.Roles
{
    public class RolesUpdateRequestValidator : AbstractValidator<RolesUpdateRequestDto>
    {
        public RolesUpdateRequestValidator() 
        {
            RuleFor(roles =>roles.RoleId)
               .NotNull().WithMessage("RoleId is Required.")
               .GreaterThan(0).WithMessage("Role Id must be greater than Zero.");

            RuleFor(roles => roles.RoleName)
           .NotEmpty().WithMessage("RoleName Is Required")
           .Length(0, 100).WithMessage("Role Name must be between 0 and 100 characters.");

            RuleFor(roles => roles.PermissionGroupId)
              .NotNull().WithMessage("PermissionGroupId is Required.")
              .GreaterThan(0).WithMessage("Permission Group Id must be greater than Zero.");

            RuleFor(roles => roles.UpdatedBy)
              .NotNull().WithMessage("UpdatedBy is Required.")
              .GreaterThan(0).WithMessage("Updated By must be greater than Zero.");

            RuleFor(roles => roles.IsActive)
               .NotNull().WithMessage("Is Active must be true or false.");

            RuleFor(roles => roles.IsDelete)
              .NotNull().WithMessage("Is Delete must be true or false.");

        }
    }
}
