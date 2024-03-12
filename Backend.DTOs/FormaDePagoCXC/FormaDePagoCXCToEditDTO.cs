namespace Backend.DTOs.FormaDePagoCXC
{
    public class FormaDePagoCXCToEditDTO
    {
        public int Id { get; set; }        
        public required string Codigo { get; set; }
        public required string NombreForma { get; set; }
        
    }
}