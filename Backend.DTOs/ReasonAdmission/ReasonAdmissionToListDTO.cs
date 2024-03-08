namespace Backend.DTOs.ReasonAdmission
{
    public class ReasonAdmissionToListDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}