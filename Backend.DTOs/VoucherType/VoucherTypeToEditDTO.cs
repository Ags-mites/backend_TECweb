namespace Backend.DTOs.VoucherType
{
    public class VoucherTypeToEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
    }
}