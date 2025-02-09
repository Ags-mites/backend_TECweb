using Backend.DTOs.Cities;
using Backend.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DTOs.Invoice
{
    public class InvoiceToCreateDTO
    {
        public required int Id { get; set; }
        public required string InvoiceNumber { get; set; } // Número de factura (generado automáticamente)
        public required DateTime Date { get; set; }

        // Relación con Ciudad
        public required int CityId { get; set; }
        public required CitiesToCreateDTO City { get; set; }

        // Relación con Cliente (opcional, si se desea asociar la factura a un cliente)
        public required int ClientId { get; set; }
        public ClientsToCreateDTO Client { get; set; }

        // Detalles de la factura
        public required ICollection<InvoiceToCreateDTO> Details { get; set; }
    }
}
