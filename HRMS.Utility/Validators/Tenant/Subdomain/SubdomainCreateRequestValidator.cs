using FluentValidation;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Tenant.Subdomain
{
    public class SubdomainCreateRequestValidator : AbstractValidator<SubdomainCreateRequestDto>
    {
        public SubdomainCreateRequestValidator()
        {
            RuleFor(subdomain => subdomain.SubdomainName)
                .NotEmpty().WithMessage("Subdomain Name is Required.")
                .Length(3, 100).WithMessage("Subdomain Name must be between 3 and 100 characters.");

            RuleFor(subdomain => subdomain.DomainID)
                .NotNull().WithMessage("Domain ID is Required.")
                .GreaterThan(0).WithMessage("Domain ID must be greater than 0.");

            RuleFor(subdomain => subdomain.CreatedBy)
                .NotNull().WithMessage("CreatedBy is Required.")
                .GreaterThan(0).WithMessage("CreatedBy must be greater than 0.");

            RuleFor(subdomain => subdomain.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");
        }
    }
}
