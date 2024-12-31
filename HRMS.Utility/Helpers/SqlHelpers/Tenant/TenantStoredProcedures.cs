using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Helpers.SqlHelpers.Tenant
{
    public class TenantStoredProcedures
    {
        public const string GetTenants = "spTenantGetAll";
        public const string GetTenant = "spTenantGet";
        public const string CreateTenant = "spTenantAdd";
        public const string UpdateTenant = "spTenantUpdate";
        public const string DeleteTenant = "spTenantDelete";
    }
}
