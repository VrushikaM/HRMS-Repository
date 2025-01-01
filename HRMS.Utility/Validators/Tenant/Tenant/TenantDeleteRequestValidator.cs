using FluentValidation;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;

namespace HRMS.Utility.Validators.Tenant.Tenant
{
    public class TenantDeleteRequestValidator : AbstractValidator<TenantDeleteRequestDtos>
    {
        public TenantDeleteRequestValidator()
        {
            RuleFor(tenant => tenant.TenantID)
               .NotNull().WithMessage("Tenant Id is Required.")
               .GreaterThan(0).WithMessage("Tenant Id must be greater than Zero.");
        }
    }
}
