using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;


// Wrapper class for Domain repository classes 
// Most likely not needed but provides a centralized
// class to interface with multiple domain repositories 
namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private readonly TestDbContext _context;

        // Domain repos
        private IHealthFacilityRepository? healthFacilityRepository;
        private IHealthFacilityServiceRepository? healthFacilityServiceRepository;
        private IPractitionerRepository? practitionerRepository;
        private IPractitionerServiceRepository? practitionerServiceRepository;
        private IServiceRepository? serviceRepository;
        private IPaymentModalityRepository? paymentModalityRepository;
        private ITreatmentModalityRepository? treatmentModalityRepository;

        public RepositoryWrapper(TestDbContext context)
        {
            _context = context;
        }

        public IHealthFacilityRepository HealthFacilityRepository
        {
            get
            {
                if (healthFacilityRepository == null)
                {
                    healthFacilityRepository = new HealthFacilityRepository(_context);
                }

                return healthFacilityRepository;
            }   
        }
        public IHealthFacilityServiceRepository HealthFacilityServiceRepository
        {
            get
            {
                if (healthFacilityServiceRepository == null)
                {
                    healthFacilityServiceRepository = new HealthFacilityServiceRepository(_context);
                }

                return healthFacilityServiceRepository;
            }
        }

        public IPractitionerRepository PractitionerRepository
        {
            get
            {
                if (practitionerRepository == null)
                {
                    practitionerRepository = new PractitionerRepository(_context);
                }

                return practitionerRepository;
            }
        }

        public IPractitionerServiceRepository PractitionerServiceRepository
        {
            get
            {
                if (practitionerServiceRepository == null)
                {
                    practitionerServiceRepository = new PractitionerServiceRepository(_context);
                }

                return practitionerServiceRepository;
            }
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                if (serviceRepository == null)
                {
                    serviceRepository = new ServiceRepository(_context);
                }

                return serviceRepository;
            }
        }

        public ITreatmentModalityRepository TreatmentModalityRepository
        {
            get
            {
                if (treatmentModalityRepository == null)
                {
                    treatmentModalityRepository = new TreatmentModalityRepository(_context);
                }

                return treatmentModalityRepository;
            }
        }

        public IPaymentModalityRepository PaymentModalityRepository
        {
            get
            {
                if (paymentModalityRepository == null)
                {
                    paymentModalityRepository = new PaymentModalityRepository(_context);
                }

                return paymentModalityRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
