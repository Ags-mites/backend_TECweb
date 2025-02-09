namespace Backend.Entities
{
    public class EntryDetail
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public int Account { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EntryHeader EntryHeader { get; set; }
    }
}