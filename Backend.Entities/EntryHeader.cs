namespace Backend.Entities
{
    public class EntryHeader
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public required string Numeration { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string EntryType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<EntryDetail> EntryDetails { get; set; } = new List<EntryDetail>();
    }
}