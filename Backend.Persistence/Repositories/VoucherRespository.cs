using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class VoucherRespository: BaseRepository<Voucher>,
    IVoucherRespository
    {
        public VoucherRespository(DataContext context)
        :base(context)
        {
            
        }
    }
}