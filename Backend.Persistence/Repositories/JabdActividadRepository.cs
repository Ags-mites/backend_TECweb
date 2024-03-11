using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class JabdActividadRepository: BaseRepository<JabdActividad>, IJabdActividadRepository
    {
        public JabdActividadRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}