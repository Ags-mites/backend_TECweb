namespace Backend.DTOs.CobradorCXC
{
    public class CobradorCXCToCreateDTO
    {
        public required string Cedula { get; set; }
        public required string NombreCobrador { get; set; }
        public required string Direccion { get; set; }

        public required string Prueba { get; set; }

    }
}