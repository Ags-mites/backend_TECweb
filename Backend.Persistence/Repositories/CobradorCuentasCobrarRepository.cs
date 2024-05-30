using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class CobradorCuentasCobrarRepository: BaseRepository<CobradorCuentasCobrar>, ICobradorCuentasCobrarRepository
    {
        public CobradorCuentasCobrarRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}