namespace Backend.DTOs.PayrollHeader
{
    public class PayrollHeaderToCreateDTO
    {
        public int WorkerId { get; set; }
        public string? Description { get; set; }
        public DateTime DatePayroll { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}