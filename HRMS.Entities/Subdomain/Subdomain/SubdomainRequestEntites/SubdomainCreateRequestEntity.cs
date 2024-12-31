namespace HRMS.Entities.Subdomain.Subdomain.SubdomainRequestEntites
{
    public class SubdomainCreateRequestEntity
    {
        public int DomainID
        {
            get; set;
        }
        public string SubdomainName { get; set; } = string.Empty;
        public int CreatedBy
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }
    }
}
