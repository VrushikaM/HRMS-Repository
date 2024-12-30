using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Helpers.SqlHelpers.Subdomain
{
    public  static class SubdomainStoredProcedures
    {
        public const string GetSubdomains = "spSubdomainsGetAll";
        public const string GetSubdomain = "spSubdomainGet";
        public const string CreateSubdomain = "spSubdomainAdd";
        public const string UpdateSubdomain = "spSubdomainUpdate";
        public const string DeleteSubdomain = "spSubdomainDelete";
    }
}
