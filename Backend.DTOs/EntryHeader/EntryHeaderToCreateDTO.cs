namespace Backend.DTOs.EntryHeader
{
    public class EntryHeaderToCreateDTO
    {
        public DateTime EntryDate { get; set; }
        public required string Numeration { get; set; }
        public string? Notes { get; set; }

    }
}