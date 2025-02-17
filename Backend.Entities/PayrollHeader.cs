namespace Backend.Entities
{
    public class PayrollHeader
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public DateTime DatePayroll { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int Workerid { get; set; }
        public required Worker Worker { get; set; }
        public ICollection<PayrollDetail> PayrollDetails { get; set; } = new List<PayrollDetail>();
    }
}