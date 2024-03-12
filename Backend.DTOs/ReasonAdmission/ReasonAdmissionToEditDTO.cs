namespace Backend.DTOs.ReasonAdmission
{
    public class ReasonAdmissionToEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Status { get; set; }
    }
}