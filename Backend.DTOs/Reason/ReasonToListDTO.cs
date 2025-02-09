namespace Backend.DTOs.Reason
{
    public class ReasonToListDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}