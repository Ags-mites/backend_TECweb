using Dtos = Backend.DTOs.InvoiceDetail;

namespace Backend.DTOs.Invoice
{
    public class InvoiceToCreateDTO
    {
        public required string InvoiceNumber { get; set; }
        public required DateTime Date { get; set; }
        public required int CityId { get; set; }
        public required int ClientId { get; set; }
        
        public required List<Dtos.InvoiceDetailToCreateDTO> invoiceDetails { get; set; }
    }
}
