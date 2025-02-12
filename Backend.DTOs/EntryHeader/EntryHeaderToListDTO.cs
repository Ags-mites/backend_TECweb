using Backend.DTOs.VoucherType;

namespace Backend.DTOs.Voucher
{
    public class EntryHeaderToListDTO
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public required string Numeration { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<EntryDetailToListDTO> EntryDetails { get; set; } = new();

    }
}

