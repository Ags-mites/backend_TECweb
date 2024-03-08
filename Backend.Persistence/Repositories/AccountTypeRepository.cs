using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class AccountTypeRepository: BaseRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(DataContext context)
        :base(context)
        {

        }
    }
}