using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public required string Article { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public int InvoiceId { get; set; }
        public required Invoice Invoice { get; set; }
    }
}
