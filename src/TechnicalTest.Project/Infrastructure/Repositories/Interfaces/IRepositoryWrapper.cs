
// Interface for the repository wrapper
namespace TechnicalTest.Project.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {

        // Repositories for models 
        IHealthFacilityRepository HealthFacilityRepository { get; }
        IHealthFacilityServiceRepository HealthFacilityService { get; }
        IPractitionerRepository PractitionerRepository { get; }
        IPractitionerServiceRepository PractitionerService { get; }
        IServiceRepository ServiceRepository { get; }   
        void Save();

    }
}
