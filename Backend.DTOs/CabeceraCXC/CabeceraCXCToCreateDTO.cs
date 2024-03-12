namespace Backend.DTOs.CabeceraCXC
{
    public class CabeceraCXCToCreateDTO
    {
        public string? numeroFactura { get; set; }
        public string? fechaFactura { get; set; }
        public string? valorFactura { get; set; }
        public string? clienteFactura { get; set; }
        public string? fechaDetalle { get; set; }
        public string? valorDetalle { get; set; }
        public string? cobradorDetalle { get; set; }
        public string? metodoDetalle { get; set; }
        
    }
}