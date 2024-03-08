using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class AccountRepository: BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}