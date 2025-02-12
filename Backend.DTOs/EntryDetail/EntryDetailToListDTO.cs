namespace Backend.DTOs.EntryDetail
{
    public class EntryDetailToListDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public required string AccountName { get; set; }
        public string Description { get; set; } = string.Empty;

        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}