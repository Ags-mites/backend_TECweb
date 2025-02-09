namespace Backend.Entities
{
    public class EntryHeader
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string VoucherType { get; set; } = string.Empty;
        public string Numeration { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<EntryDetail> EntryDetails { get; set; } = new List<EntryDetail>();
    }
}