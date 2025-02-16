using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class ReasonRepository: BaseRepository<Reason>, IReasonRepository
    {
        public  ReasonRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}