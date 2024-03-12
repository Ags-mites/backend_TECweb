using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class FacturacionClienteRepository: BaseRepository<FacturacionCliente>, IFacturacionClienteRepository
    {
        public FacturacionClienteRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}