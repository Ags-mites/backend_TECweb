using Dtos = Backend.DTOs.InvoiceDetail;

namespace Backend.DTOs.Invoice
{
    public class InvoiceToEditDTO
    {
        public required int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public required DateTime Date { get; set; }
        public required int CityId { get; set; }
        public required int ClientId { get; set; }
        
        public List<Dtos.InvoiceDetailToEditDTO>? invoiceDetails { get; set; }
    }
}
