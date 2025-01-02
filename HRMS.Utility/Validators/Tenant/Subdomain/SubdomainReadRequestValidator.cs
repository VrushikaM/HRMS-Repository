using FluentValidation;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Tenant.Subdomain
{
    public class SubdomainReadRequestValidator : AbstractValidator<SubdomainReadRequestDto>
    {
        public SubdomainReadRequestValidator()
        {
            RuleFor(x => x.SubdomainId)
                .NotNull().WithMessage("Subdomain ID is Required.")
                .GreaterThan(0).WithMessage("Subdomain ID must be greater than Zero.");
        }
    }
}
