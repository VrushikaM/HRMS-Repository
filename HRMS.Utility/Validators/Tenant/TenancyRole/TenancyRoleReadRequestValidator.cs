using FluentValidation;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos;

namespace HRMS.Utility.Validators.Tenant.TenancyRole
{
    public class TenancyRoleReadRequestValidator : AbstractValidator<TenancyRoleReadRequestDto>
    {
        public TenancyRoleReadRequestValidator()
        {
            RuleFor(x => x.TenancyRoleID)
                .NotNull().WithMessage("Tenancy Role Id is Required.")
                .GreaterThan(0).WithMessage("Tenancy Role Id must be greater than Zero.");
        }
    }
}
