using Backend.DTOs.InvoiceDetail;

namespace Backend.DTOs.Invoice
{
    public class InvoiceToListDTO
    {
        public required int Id { get; set; }
        public required string InvoiceNumber { get; set; } 
        public required DateTime Date { get; set; }
        public required int CityId { get; set; }
        public required int ClientId { get; set; }

        public List<InvoiceDetailToListDTO> InvoiceDetails { get; set; } = new();
    }
}
