namespace Backend.Entities
{
    public class FacturacionCliente
    {
        public int Id { get; set; }
        public string? DescripcionProd { get; set; }
        public int? CantidadProd { get; set; }
        public int? PrecioUnitario { get; set; }
        public int? PrecioTotal { get; set; }
    
    }
}

