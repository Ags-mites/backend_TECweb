using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class EntryDetailRepository: BaseRepository<EntryDetail>, IEntryDetailRepository
    {
        public EntryDetailRepository(DataContext context)
        :base(context){
            
        }
    }
}