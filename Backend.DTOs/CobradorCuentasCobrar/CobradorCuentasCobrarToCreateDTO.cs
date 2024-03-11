namespace Backend.DTOs.CobradorCuentasCobrar
{
    public class CobradorCuentasCobrarToCreateDTO
    {
        public required string Cedula { get; set; }
        public required string NombreCobrador { get; set; }
        public required string Direccion { get; set; }

    }
}