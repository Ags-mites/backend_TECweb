using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class WorkersRepository: BaseRepository<Workers>,
    IWorkersRepository
    {
        public WorkersRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}