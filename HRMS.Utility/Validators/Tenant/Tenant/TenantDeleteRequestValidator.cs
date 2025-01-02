using FluentValidation;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;

namespace HRMS.Utility.Validators.Tenant.Tenant
{
    public class TenantDeleteRequestValidator : AbstractValidator<TenantDeleteRequestDtos>
    {
        public TenantDeleteRequestValidator()
        {
            RuleFor(tenant => tenant.TenantId)
               .NotNull().WithMessage("Tenant ID is Required.")
               .GreaterThan(0).WithMessage("Tenant ID must be greater than Zero.");
        }
    }
}
