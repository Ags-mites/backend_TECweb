using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class ClientsFacRepository: BaseRepository<ClientsFac>, IClientsFacRepository
    {
        public ClientsFacRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}