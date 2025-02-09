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
    }
}