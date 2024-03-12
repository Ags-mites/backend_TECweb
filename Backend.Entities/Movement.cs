namespace Backend.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public string? Contact { get; set; }
        public string? DescriptionVoucher { get; set; }
        public required decimal Debit { get; set; }
        public required decimal Credit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

                
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public int VoucherId { get; set; }
        public Account Accounts { get; set; }
        public AccountType AccountType { get; set; }
        public required Voucher Voucher { get; set; }
    }
}