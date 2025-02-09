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
        public string InvoiceNumber { get; set; } // Número de factura (generado automáticamente)
        public DateTime Date { get; set; }

        // Relación con Ciudad
        public int CityId { get; set; }
        public Cities City { get; set; }

        // Relación con Cliente (opcional, si se desea asociar la factura a un cliente)
        public int ClientId { get; set; }
        public Clients Client { get; set; }

        // Detalles de la factura
        public ICollection<InvoiceDetail> Details { get; set; }
    }
}
