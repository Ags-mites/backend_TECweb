namespace Backend.DTOs.Worker
{
    public class WorkerToListDTO
    {
        public int Id { get; set; }
        public required string IdCard { get; set; }
        public required string Name { get; set; }
        public DateTime DateAdmission { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}