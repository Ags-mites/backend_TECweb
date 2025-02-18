using Backend.DTOs.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs.InvoiceDetail
{
    public class InvoiceDetailToEditDTO
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
