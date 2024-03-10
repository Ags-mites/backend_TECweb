namespace Backend.DTOs.Voucher
{
    public class VoucherToListDTO
    {
        public int Numeration { get; set; }
        public required string CodeVoucher { get; set; }
        public string? DescriptionVoucher { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdVoucherType { get; set; }
        public int IdMovement { get; set; }
    }
}