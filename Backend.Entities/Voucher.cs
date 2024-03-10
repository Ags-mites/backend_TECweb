namespace Backend.Entities
{
    public class Voucher
    {
        public int Id { get; set; }
        public int Numeration { get; set; }
        public required string CodeVoucher { get; set; }
        public string? DescriptionVoucher { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int VoucherTypeId { get; set; }
        public int MovementId { get; set; }
        public required VoucherType VoucherTypes { get; set; }
        public required Movement Movements { get; set; }
    }
}