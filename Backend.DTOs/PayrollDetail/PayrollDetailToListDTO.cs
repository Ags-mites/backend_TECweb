namespace Backend.DTOs.PayrollDetail
{
    public class PayrollDetailToListDTO
    {
public int Id { get; set; }
        public int ReasonId { get; set; }
        public int PayrollId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}