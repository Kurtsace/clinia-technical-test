using TechnicalTest.Project.Domain;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class PractitionerRepository : RepositoryBase<Practitioner>, IPractitionerRepository
    {
        public PractitionerRepository(TestDbContext testDbContext) : base(testDbContext)
        {
        }
    }
}
