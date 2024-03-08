using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class CiudadEntrFacRepository: BaseRepository<ICiudadEntrFacRepository>, ICiudadEntrFacRepository
    {
        public CiudadEntrFacRepository(DataContext context)
        :base(context)
        {

        }
    }
}