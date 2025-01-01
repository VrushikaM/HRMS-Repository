using FluentValidation;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos;

namespace HRMS.Utility.Validators.Tenant.TenancyRole
{
    public class TenancyRoleDeleteRequestValidator : AbstractValidator<TenancyRoleDeleteRequestDto>
    {
        public TenancyRoleDeleteRequestValidator()
        {
            RuleFor(x => x.TenancyRoleID)
                .NotNull().WithMessage("Tenancy Role Id is Required.")
                .GreaterThan(0).WithMessage("Tenancy Role Id must be greater than Zero.");
        }
    }
}
