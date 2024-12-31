using FluentValidation;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Subdomain.Subdomain
{
    public class SubdomainReadRequestValidator : AbstractValidator<SubdomainReadRequestDto>
    {
        public SubdomainReadRequestValidator()
        {
            RuleFor(x => x.SubdomainID)
                .NotNull().WithMessage("Subdomain ID is Required.")
                .GreaterThan(0).WithMessage("Subdomain ID must be greater than Zero.");
        }
    }
}
