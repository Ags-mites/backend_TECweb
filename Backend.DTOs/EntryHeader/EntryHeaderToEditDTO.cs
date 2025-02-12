using Dtos = Backend.DTOs.EntryDetail;

namespace Backend.DTOs.EntryHeader
{
    public class EntryHeaderToEditDTO
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public required string Numeration { get; set; }
        public string? Notes { get; set; }
        public List<Dtos.EntryDetailToEditDTO>? EntryDetails { get; set; }
    }
}