namespace Backend.Entities
{
    public class PayrollDetail
    {
        public int Id { get; set; }
        public required decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int ReasonId { get; set; }
        public int PayrollId { get; set; }

    }
}