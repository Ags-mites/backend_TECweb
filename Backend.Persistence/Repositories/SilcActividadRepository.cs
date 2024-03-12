using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class SilcActividadRepository: BaseRepository<SilcActividad>, ISilcActividadRepository
    {
        public SilcActividadRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}