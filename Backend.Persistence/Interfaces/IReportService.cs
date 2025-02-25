using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Persistence.Interfaces
{
    public interface IReportService<T> where T : class
    {
        Task<List<T>> GenerateGroupedReportAsync();
    }
}
