using FluentValidation;
using HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos;
using HRMS.Dtos.User.User.UserRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.Tenant.Organization
{
    public class OrganizationReadRequestValidator : AbstractValidator<OrganizationReadRequestDto>
    {
        public OrganizationReadRequestValidator()
        {
            RuleFor(org => org.OrganizationID)
                .GreaterThan(0).WithMessage("OrganizationID must be greater than Zero.");

            RuleFor(org => org.OrganizationName)
                .Length(2, 100).WithMessage("Organization Name must be between 2 and 100 characters.")
                .When(org => !string.IsNullOrEmpty(org.OrganizationName)); 

        

            RuleFor(org => org.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedAt cannot be in the future.");

           
        }
    }
}
