namespace HRMS.Utility.Helpers.SqlHelpers.Tenant
{
    public static class TenancyRoleStoredProcedure
    {
        public const string GetTenancyRoles = "spTenancyRoleGetAll";
        public const string GetTenancyRoleById = "spTenancyRoleGet";
        public const string CreateTenancyRole = "spTenancyRoleAdd";
        public const string UpdateTenancyRole = "spTenancyRoleUpdate";
        public const string DeleteTenancyRole = "spTenancyRoleDelete";
    }
}
