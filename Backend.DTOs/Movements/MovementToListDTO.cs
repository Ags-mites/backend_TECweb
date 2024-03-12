namespace Backend.DTOs.Movements
{
    public class MovementToListDTO
    {
        public int Id { get; set; }
        public string? Contact { get; set; }
        public string? DescriptionVoucher { get; set; }
        public required decimal Debit { get; set; }
        public required decimal Credit { get; set; }
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VoucherId { get; set; }
    }
}