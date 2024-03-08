namespace Backend.Entities
{
    public class VoucherType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IEnumerable<Voucher>? Vouchers { get; set; }
    }
}