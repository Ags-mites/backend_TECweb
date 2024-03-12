namespace Backend.DTOs.ReasonAdmission
{
    public class ReasonAdmissionToCreateDTO
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Status { get; set; }
    }
}