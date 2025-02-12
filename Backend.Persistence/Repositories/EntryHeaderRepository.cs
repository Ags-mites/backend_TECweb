using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class EntryHeaderRepository: BaseRepository<EntryHeader>, IEntryHeaderRepository
    {
        public EntryHeaderRepository(DataContext context)
        :base(context){
            
        }
    }
}