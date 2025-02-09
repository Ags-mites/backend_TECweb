using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class MR_ACTIVIDADRepository: BaseRepository<MR_ACTIVIDAD>, IMR_ACTIVIDADRepository
    {
        public MR_ACTIVIDADRepository (DataContext context)
        :base(context)
        {

        }
    }
}