using FluentValidation;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Tenant.Subdomain
{
    public class SubdomainDeleteRequestValidator : AbstractValidator<SubdomainDeleteRequestDto>
    {
        public SubdomainDeleteRequestValidator()
        {
            RuleFor(x => x.SubdomainID)
                .NotNull().WithMessage("Subdomain ID is Required.")
                .GreaterThan(0).WithMessage("Subdomain ID must be greater than Zero.");
        }
    }
}
