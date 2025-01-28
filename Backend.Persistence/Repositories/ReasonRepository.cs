using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class ReasonRepository: BaseRepository<Reasons>, IReasonRepository
    {
        public  ReasonRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}