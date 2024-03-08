namespace Backend.DTOs.FormaDePagoCXC
{
    public class FormaDePagoCXCToListDTO
    {
        public int Id { get; set; }        
        public required string Codigo { get; set; }
        public required string NombreForma { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}