using Backend.Entities;
using Backend.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence.Repositories
{
    public class InvoiceDetailRepository: BaseRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(DataContext context)
        : base(context)
        {

        }
    }
}
