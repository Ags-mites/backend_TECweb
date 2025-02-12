namespace Backend.DTOs.EntryDetail
{
    public class EntryDetailToCreateDTO
    {
        public int AccountId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        
    }
}