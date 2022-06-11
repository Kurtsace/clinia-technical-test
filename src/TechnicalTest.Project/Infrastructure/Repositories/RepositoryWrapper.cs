using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;


// Wrapper class for Domain repository classes 
// Most likely not needed but provides a centralized
// class to interface with multiple domain repositories 
namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private readonly TestDbContext _context;
        private IHealthFacilityRepository? healthFacilityRepository;
        private IHealthFacilityServiceRepository? healthFacilityServiceRepository;
        private IPractitionerRepository? practitionerRepository;
        private IPractitionerServiceRepository? practitionerServiceRepository;
        private IServiceRepository? serviceRepository;

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
        public IHealthFacilityServiceRepository HealthFacilityService
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

        public IPractitionerServiceRepository PractitionerService
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
