using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class PractitionerServiceRepository : RepositoryBase<PractitionerService>, IPractitionerServiceRepository
    {
        public PractitionerServiceRepository(TestDbContext testDbContext) : base(testDbContext)
        {
        }
    }
}
