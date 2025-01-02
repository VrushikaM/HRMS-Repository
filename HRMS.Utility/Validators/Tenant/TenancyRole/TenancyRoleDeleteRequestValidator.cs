using FluentValidation;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos;

namespace HRMS.Utility.Validators.Tenant.TenancyRole
{
    public class TenancyRoleDeleteRequestValidator : AbstractValidator<TenancyRoleDeleteRequestDto>
    {
        public TenancyRoleDeleteRequestValidator()
        {
            RuleFor(x => x.TenancyRoleId)
                .NotNull().WithMessage("Tenancy Role ID is Required.")
                .GreaterThan(0).WithMessage("Tenancy Role ID must be greater than Zero.");
        }
    }
}
