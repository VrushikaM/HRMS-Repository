using FluentValidation;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;

namespace HRMS.Utility.Validators.Tenant.Tenant
{
    public class TenantReadRequestValidator : AbstractValidator<TenantReadRequestDtos>
    {
        public TenantReadRequestValidator()
        {
            RuleFor(tenant => tenant.TenantID)
               .NotNull().WithMessage("Tenant ID is Required.")
               .GreaterThan(0).WithMessage("Tenant ID must be greater than Zero.");
        }
    }
}
