namespace Backend.Entities
{
    public class ClientsFac
    {
        public int Id { get; set; }
        public string? Ruc { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime? TimeCli { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public int? CiudadEntrFacId { get; set; }
        public CiudadEntrFac? CiudadEntrFac { get; set; }

    
    }
}

