using FluentValidation;
using HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.Tenant.Organization
{
    public class OrganizationDeleteRequestValidator : AbstractValidator<OrganizationDeleteRequestDto>
    {
        public OrganizationDeleteRequestValidator()
        {
           
            RuleFor(org => org.OrganizationId)
                .GreaterThan(0).WithMessage("OrganizationId must be greater than Zero.");
        }
    }
}
