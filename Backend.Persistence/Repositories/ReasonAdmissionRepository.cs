using Backend.Entities;
using Backend.Persistence.Interfaces;

namespace Backend.Persistence.Repositories
{
    public class ReasonAdmissionRepository: BaseRepository<ReasonAdmission>, IReasonAdmissionRepository
    {
        public  ReasonAdmissionRepository(DataContext context)
        :base(context)
        {
            
        }
    }
}