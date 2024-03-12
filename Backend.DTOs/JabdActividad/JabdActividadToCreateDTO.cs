namespace Backend.DTOs.JabdActividad
{
    public class JabdActividadToCreateDTO
    {
        public int Id { get; set; }
        public required string NombreJabd { get; set; }
        public required string UsuarioJabd { get; set; }

    }
}