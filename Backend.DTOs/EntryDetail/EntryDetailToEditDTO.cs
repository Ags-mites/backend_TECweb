namespace Backend.DTOs.VoucherType
{
    public class EntryDetailToEditDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
    }
}