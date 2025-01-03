﻿namespace HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationRequestDtos
{
    public class TenantRegistrationCreateRequestDto
    {
        public string SubdomainName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
