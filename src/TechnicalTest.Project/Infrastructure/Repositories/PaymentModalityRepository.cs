using TechnicalTest.Project.Domain.Modalities;
using TechnicalTest.Project.Infrastructure.Repositories.Interfaces;

namespace TechnicalTest.Project.Infrastructure.Repositories
{
    public class PaymentModalityRepository : RepositoryBase<PaymentModality>, IPaymentModalityRepository
    {
        public PaymentModalityRepository(TestDbContext context) : base(context)
        {
        }
    }
}
