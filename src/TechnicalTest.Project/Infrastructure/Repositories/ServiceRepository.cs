using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(TestDbContext testDbContext) : base(testDbContext)
        {
        }
    }
}
