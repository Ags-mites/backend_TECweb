namespace Backend.DTOs.Voucher
{
    public class EntryHeaderToCreateDTO
    {
        public int Numeration { get; set; }
        public required string CodeVoucher { get; set; }
        public string? DescriptionVoucher { get; set; }
        public int VoucherTypeId { get; set; }
    }
}