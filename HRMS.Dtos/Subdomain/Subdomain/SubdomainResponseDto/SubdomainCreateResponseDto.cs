namespace HRMS.Dtos.Subdomain.Subdomain.SubdomainResponseDto
{
    public class SubdomainCreateResponseDto
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
        public int CreatedBy
        {
            get; set;
        }
        public DateTime CreatedAt
        {
            get; set;
        }
        public int UpdatedBy
        {
            get; set;
        }
        public DateTime UpdatedAt
        {
            get; set;
        }
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
