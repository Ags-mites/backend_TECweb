using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class FormaDePagoCXCRepository: BaseRepository<FormaDePagoCXC>, IFormaDePagoCXCRepository
    {
        public FormaDePagoCXCRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}