using Backend.DTOs.PayrollDetail;

namespace Backend.DTOs.PayrollHeader
{
    public class PayrollHeaderToListDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Workerid { get; set; }
        public string? Description { get; set; }
        public DateTime DatePayroll { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<PayrollDetailToListDTO> PayrollDetails { get; set; } = new();
    }
}