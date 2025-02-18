using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? InvoiceNumber { get; set; } // Número de factura (generado automáticamente)
        public DateTime Date { get; set; }

        public int CityId { get; set; }
        public required Cities City { get; set; }

        public int ClientId { get; set; }
        public required Clients Client { get; set; }

        // Detalles de la factura
        public ICollection<InvoiceDetail>? Details { get; set; }
    }
}
