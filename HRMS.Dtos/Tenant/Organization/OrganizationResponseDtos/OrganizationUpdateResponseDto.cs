﻿namespace HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos
{
    public class OrganizationUpdateResponseDto
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
