namespace Backend.DTOs.VoucherType
{
    public class EntryDetailToCreateDTO
    {
        public DateTime EntryDate { get; set; }
        public string VoucherType { get; set; } = string.Empty;
        public string Numeration { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}