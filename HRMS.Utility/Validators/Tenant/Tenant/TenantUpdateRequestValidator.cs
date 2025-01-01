using FluentValidation;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;

namespace HRMS.Utility.Validators.Tenant.Tenant
{
    public class TenantUpdateRequestValidator : AbstractValidator<TenantUpdateRequestDtos>
    {
        public TenantUpdateRequestValidator()
        {
            RuleFor(tenant => tenant.TenantID)
               .NotNull().WithMessage("Tenant Id is Required.")
               .GreaterThan(0).WithMessage("Tenant Id must be greater than Zero.");

            RuleFor(tenant => tenant.OrganizationID)
                  .NotNull().WithMessage("Organization Id is Required.")
                  .GreaterThan(0).WithMessage("Organization Id must be greater than Zero.");

            RuleFor(tenant => tenant.DomainID)
              .NotNull().WithMessage("Domain Id is Required.")
              .GreaterThan(0).WithMessage("Domain Id must be greater than Zero.");

            RuleFor(tenant => tenant.SubdomainID)
              .NotNull().WithMessage("Subdomain Id is Required.")
              .GreaterThan(0).WithMessage("Subdomain Id must be greater than Zero.");

            RuleFor(tenant => tenant.TenantName)
                 .NotEmpty().WithMessage("Tenant Name is Required.")
                 .Length(2, 50).WithMessage("Tenant Name must be between 2 and 50 characters.");

            RuleFor(tenant => tenant.UpdatedBy)
             .NotNull().WithMessage("UpdatedBy is Required.")
             .GreaterThan(0).WithMessage("UpdatedBy must be greater than Zero.");

            RuleFor(tenant => tenant.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");

            RuleFor(tenant => tenant.IsDelete)
              .NotNull().WithMessage("IsDelete must be true or false.");
        }
    }
}
