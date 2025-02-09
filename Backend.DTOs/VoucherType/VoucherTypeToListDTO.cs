namespace Backend.DTOs.VoucherType
{
    public class VoucherTypeToListDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}