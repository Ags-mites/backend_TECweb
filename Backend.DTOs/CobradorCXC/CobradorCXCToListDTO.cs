namespace Backend.DTOs.CobradorCXC
{
    public class CobradorCXCToListDTO
    {
        public int Id { get; set; }
        public required string Cedula { get; set; }
        public required string NombreCobrador { get; set; }
        public required string Direccion { get; set; }
        public required string Prueba { get; set; }

        public DateTime CreatedAt { get; set; }    
        
    }
}