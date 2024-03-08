namespace Backend.Entities
{
    public class CobradorCXC
    {
        public int Id { get; set; }
        public required string Cedula { get; set; }
        public required string NombreCobrador { get; set; }
        public required string Direccion { get; set; }
        public required string Prueba { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        

    }
}