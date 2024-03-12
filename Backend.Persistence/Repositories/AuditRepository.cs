using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class AuditRepository: BaseRepository<AuditAM>, IAuditAMRepository
    {
        public AuditRepository (DataContext context)
        :base(context)
        {

        }
    }
}