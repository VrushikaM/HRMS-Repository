using FluentValidation;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.User.Roles
{
    public class RolesDeleteRequestValidator : AbstractValidator<RolesDeleteRequestDto>
    {
        public RolesDeleteRequestValidator()
        {

            RuleFor(roles => roles.RoleId )
               .NotNull().WithMessage("RoleId is Required.")
               .GreaterThan(0).WithMessage("Role Id must be greater than Zero.");

        }
    }
}
