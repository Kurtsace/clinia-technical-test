using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class HealthFacilityServiceRepository : RepositoryBase<HealthFacilityService>, IHealthFacilityServiceRepository

    {
        public HealthFacilityServiceRepository(TestDbContext testDbContext) : base(testDbContext)
        {
        }
    }
}
