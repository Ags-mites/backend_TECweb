namespace Backend.DTOs.VoucherType
{
    public class EntryDetailToEditDTO
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string VoucherType { get; set; } = string.Empty;
        public string Numeration { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}