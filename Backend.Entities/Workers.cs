namespace Backend.Entities
{
    public class Workers
    {
        public int Id { get; set; }
        public required string CI { get; set; }
        public required string Name { get; set; }
        public DateTime DateAdmission { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}