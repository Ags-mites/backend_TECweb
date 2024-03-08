using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class VoucherTypeRepository: BaseRepository<VoucherType>, IVoucherTypeRepository
    {
        public VoucherTypeRepository(DataContext context)
        :base(context){
            
        }
    }
}