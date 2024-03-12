namespace Backend.DTOs.ClientsFac
{
    public class ClientsFacToEditDTO
    {
        public int Id { get; set; }
        public required string Ruc { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? Direccion { get; set; }
        public int? CiudadEntrFacId { get; set; }
    }
}