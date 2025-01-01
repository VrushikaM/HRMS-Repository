using FluentValidation;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Validators.Tenant.Tenant
{
    public class TenantCreateRequestValidator : AbstractValidator<TenantCreateRequestDtos>
    {
        public TenantCreateRequestValidator()
        {
            RuleFor(tenant => tenant.OrganizationID)
              .NotNull().WithMessage("Organization ID is Required.")
            .GreaterThan(0).WithMessage("Organization ID must be greater than Zero.");

            RuleFor(tenant => tenant.DomainID)
              .NotNull().WithMessage("Domain ID is Required.")
              .GreaterThan(0).WithMessage("Domain ID must be greater than Zero.");

            RuleFor(tenant => tenant.SubdomainID)
              .NotNull().WithMessage("Subdomain ID is Required.")
            .GreaterThan(0).WithMessage("Subdomain ID must be greater than Zero.");

            RuleFor(tenant => tenant.TenantName)
                 .NotEmpty().WithMessage("Tenant Name is Required.")
                 .Length(2, 50).WithMessage("Tenant Name must be between 2 and 50 characters.");

            RuleFor(tenant => tenant.CreatedBy)
             .NotNull().WithMessage("CreatedBy is Required.")
             .GreaterThan(0).WithMessage("CreatedBy must be greater than Zero.");

            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");

            RuleFor(user => user.IsDelete)
              .NotNull().WithMessage("IsDelete must be true or false.");
        }
    }
}
