namespace HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntities
{
    public class SubdomainCreateResponseEntity
    {
        public int SubdomainID
        {
            get; set;
        }
        public int DomainID
        {
            get; set;
        }
        public string SubdomainName { get; set; } = string.Empty;




        public bool IsActive
        {
            get; set;
        }
        public bool IsDelete
        {
            get; set;
        }
    }
}

