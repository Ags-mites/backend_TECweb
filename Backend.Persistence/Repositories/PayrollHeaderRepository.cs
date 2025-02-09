using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class PayrollHeaderRepository: BaseRepository<PayrollHeader>,
    IPayrollHeaderRepository
    {
        public PayrollHeaderRepository(DataContext context)
        :base(context)
        {

        }
    }
}