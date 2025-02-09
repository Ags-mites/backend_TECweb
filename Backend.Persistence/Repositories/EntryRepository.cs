using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class EntryRepository: BaseRepository<EntryHeader>, IEntryRepository
    {
        public EntryRepository(DataContext context)
        :base(context){
            
        }
    }
}