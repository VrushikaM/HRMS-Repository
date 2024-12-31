using FluentValidation;
using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationRequestDtos;

namespace HRMS.Utility.Validators.Tenant.TenantRegistration
{
    public class TenantRegistrationCreateRequestValidator : AbstractValidator<TenantRegistrationCreateRequestDto>
    {
        public TenantRegistrationCreateRequestValidator()
        {

        }
    }
}
