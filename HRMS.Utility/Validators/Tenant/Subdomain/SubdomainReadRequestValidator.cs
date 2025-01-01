using FluentValidation;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Tenant.Subdomain
{
    public class SubdomainReadRequestValidator : AbstractValidator<SubdomainReadRequestDto>
    {
        public SubdomainReadRequestValidator()
        {
            RuleFor(x => x.SubdomainID)
                .NotNull().WithMessage("Subdomain Id is Required.")
                .GreaterThan(0).WithMessage("Subdomain Id must be greater than Zero.");
        }
    }
}
