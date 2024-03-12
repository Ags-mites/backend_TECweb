namespace Backend.DTOs.Worker
{
    public class WorkerToCreateDTO
    {
        public required string CI { get; set; }
        public required string Name { get; set; }
        public DateTime DateAdmission { get; set; }
        public decimal Value { get; set; }
    }
}