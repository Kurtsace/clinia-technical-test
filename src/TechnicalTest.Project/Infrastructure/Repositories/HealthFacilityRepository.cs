using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class HealthFacilityRepository : RepositoryBase<HealthFacility>, IHealthFacilityRepository
    {
        public HealthFacilityRepository(TestDbContext testDbContext) : base(testDbContext)
        {
        }
    }
}
