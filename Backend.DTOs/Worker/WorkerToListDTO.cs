namespace Backend.DTOs.Worker
{
    public class WorkerToListDTO
    {
        public int Id { get; set; }
        public required string CI { get; set; }
        public required string Name { get; set; }
        public DateTime DateAdmission { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}