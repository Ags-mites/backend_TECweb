using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class CobradorCXCRepository: BaseRepository<CobradorCXC>, ICobradorCXCRepository
    {
        public CobradorCXCRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}