using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class PayrollDetailRepository: BaseRepository<PayrollDetail>,
    IPayrollDetailRepository
    {
        public PayrollDetailRepository(DataContext context)
        :base(context)
        {

        }
    }
}