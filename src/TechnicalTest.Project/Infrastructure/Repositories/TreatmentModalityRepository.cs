using TechnicalTest.Project.Domain.Modalities;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class TreatmentModalityRepository : RepositoryBase<TreatmentModality>, ITreatmentModalityRepository
    {
        public TreatmentModalityRepository(TestDbContext context) : base(context)
        {
        }
    }
}
