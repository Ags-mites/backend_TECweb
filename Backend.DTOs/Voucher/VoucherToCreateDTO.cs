namespace Backend.DTOs.Voucher
{
    public class VoucherToCreateDTO
    {
        public int Numeration { get; set; }
        public required string CodeVoucher { get; set; }
        public string? DescriptionVoucher { get; set; }
        public int IdVoucherType { get; set; }
        public int IdMovement { get; set; }
    }
}