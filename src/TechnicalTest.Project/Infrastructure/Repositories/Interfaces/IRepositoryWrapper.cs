
// Interface for the repository wrapper
namespace TechnicalTest.Project.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {

        // Repositories for models 
        IHealthFacilityRepository HealthFacilityRepository { get; }
        IHealthFacilityServiceRepository HealthFacilityServiceRepository { get; }
        IPractitionerRepository PractitionerRepository { get; }
        IPractitionerServiceRepository PractitionerServiceRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IPaymentModalityRepository PaymentModalityRepository { get; }
        ITreatmentModalityRepository TreatmentModalityRepository { get; }
        void Save();

    }
}
