namespace Backend.DTOs.Reason
{
    public class ReasonToEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}