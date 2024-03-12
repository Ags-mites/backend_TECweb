using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class CiudadEntrFacRepository: BaseRepository<CiudadEntrFac>, ICiudadEntrFacRepository
    {
        public CiudadEntrFacRepository(DataContext context)
        :base(context)
        {

        }
    }
}