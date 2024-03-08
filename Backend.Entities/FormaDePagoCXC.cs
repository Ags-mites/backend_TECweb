namespace Backend.Entities
{
    public class FormaDePagoCXC
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string NombreForma { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        

        public int CobradorCXCId { get; set; }
        public CobradorCXC? CobradorCXC { get; set; }

    }
}