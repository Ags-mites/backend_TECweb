using Dtos = Backend.DTOs.PayrollDetail;

namespace Backend.DTOs.PayrollHeader
{
    public class PayrollHeaderToCreateDTO
    {
        public string Number { get; set; }
        public int Workerid { get; set; }
        public string? Description { get; set; }
        public DateTime DatePayroll { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Dtos.PayrollDetailToCreateDTO>? PayrollDetails { get; set; }
    }
}