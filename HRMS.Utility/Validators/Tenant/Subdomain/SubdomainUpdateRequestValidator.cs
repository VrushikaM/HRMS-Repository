using FluentValidation;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;

namespace HRMS.Utility.Validators.Tenant.Subdomain
{
    public class SubdomainUpdateRequestValidator : AbstractValidator<SubdomainUpdateRequestDto>
    {
        public SubdomainUpdateRequestValidator()
        {
            RuleFor(x => x.SubdomainId)
              .NotNull().WithMessage("Subdomain ID is Required.")
              .GreaterThan(0).WithMessage("Subdomain ID must be greater than Zero.");

            RuleFor(subdomain => subdomain.SubdomainName)
                .NotEmpty().WithMessage("Subdomain Name is Required.")
                .Length(3, 100).WithMessage("Subdomain Name must be between 3 and 100 characters.");

            RuleFor(subdomain => subdomain.DomainId)
                .NotNull().WithMessage("Domain ID is Required.")
                .GreaterThan(0).WithMessage("Domain ID must be greater than 0.");

            RuleFor(subdomain => subdomain.UpdatedBy)
                .NotNull().WithMessage("UpdatedBy is Required.")
                .GreaterThan(0).WithMessage("UpdatedBy must be greater than 0.");

            RuleFor(subdomain => subdomain.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");

            RuleFor(subdomain => subdomain.IsDelete)
                .NotNull().WithMessage("IsDelete must be true or false.");
        }
    }
}
