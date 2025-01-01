using FluentValidation;
using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationRequestDtos;

namespace HRMS.Utility.Validators.Tenant.TenantRegistration
{
    public class TenantRegistrationCreateRequestValidator : AbstractValidator<TenantRegistrationCreateRequestDto>
    {
        public TenantRegistrationCreateRequestValidator()
        {
            RuleFor(subdomain => subdomain.SubdomainName)
             .NotEmpty().WithMessage("Subdomain Name is Required.")
             .Length(3, 100).WithMessage("Subdomain Name must be between 3 and 100 characters.");

            RuleFor(user => user.FirstName)
           .NotEmpty().WithMessage("First Name is Required.")
             .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(user => user.LastName)
          .NotEmpty().WithMessage("Last Name is Required.")
              .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage("User Name is Required.")
                .Length(2, 50).WithMessage("User Name must be between 2 and 50 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is Required.")
                .EmailAddress().WithMessage("Invalid Email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is Required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }
    }
}
