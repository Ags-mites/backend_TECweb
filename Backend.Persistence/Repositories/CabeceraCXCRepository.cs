using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class CabeceraCXCRepository: BaseRepository<CabeceraCXC>, ICabeceraCXCRepository
    {
        public CabeceraCXCRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}