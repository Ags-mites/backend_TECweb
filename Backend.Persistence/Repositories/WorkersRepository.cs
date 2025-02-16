using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class WorkersRepository: BaseRepository<Worker>,
    IWorkersRepository
    {
        public WorkersRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}