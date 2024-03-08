namespace Backend.DTOs.FormaDePagoCXC
{
    public class FormaDePagoCXCToCreateDTO
    {
        public required string Codigo { get; set; }
        public required string NombreForma { get; set; }
        
        public int CobradorCXCId { get; set; }
    }
}