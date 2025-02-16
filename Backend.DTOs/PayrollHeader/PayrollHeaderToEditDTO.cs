using Dtos = Backend.DTOs.PayrollDetail;
namespace Backend.DTOs.PayrollHeader
{
    public class PayrollHeaderToEditDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Workerid { get; set; }
        public string? Description { get; set; }
        public DateTime? DatePayroll { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public List<Dtos.PayrollDetailToEditDTO>? PayrollDetails { get; set; }
    }
}