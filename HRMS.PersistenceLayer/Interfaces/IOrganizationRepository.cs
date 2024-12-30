using HRMS.Entities.Tenant.Organization.OrganizationRequestEntities;
using HRMS.Entities.Tenant.Organization.OrganizationResponseEntities;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationReadResponseEntity>> GetOrganizations();


        Task<OrganizationReadResponseEntity> GetOrganization(int id);

        Task<OrganizationCreateResponseEntity> CreateOrganization(OrganizationCreateRequestEntity organization);


        Task<OrganizationUpdateResponseEntity> UpdateOrganization(OrganizationUpdateRequestEntity organization);

        Task<int> DeleteOrganization(OrganizationDeleteRequestEntity organization);



    }
}
