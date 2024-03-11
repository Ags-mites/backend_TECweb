namespace Backend.DTOs.CobradorCuentasCobrar
{
    public class CobradorCuentasCobrarToEditDTO
    {
        public int Id { get; set; }
        public required string Cedula { get; set; }
        public required string NombreCobrador { get; set; }
        public required string Direccion { get; set; }

    }
}