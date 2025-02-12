namespace Backend.Entities
{
    public class EntryDetail
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public required Account Account { get; set; } 

        public string Description { get; set; } = string.Empty;
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int EntryHeaderId { get; set; }
        public required EntryHeader EntryHeader { get; set; }
    }
}
