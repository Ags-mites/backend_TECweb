namespace Backend.Entities
{
    public class PayrollHeader
    {
        public int Id { get; set; }
        public int Workerid { get; set; }
        public string? Description { get; set; }
        public DateTime DatePayroll { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}