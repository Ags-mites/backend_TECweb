using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class MovementRepository: BaseRepository<Movement>, IMovementRepository
    {
        public MovementRepository(DataContext context)
        :base(context)
        {
            
        }        
    }
}