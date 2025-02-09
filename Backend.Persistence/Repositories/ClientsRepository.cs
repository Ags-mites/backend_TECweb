using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class ClientsRepository: BaseRepository<Clients>, IClientsRepository
    {
        public ClientsRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}