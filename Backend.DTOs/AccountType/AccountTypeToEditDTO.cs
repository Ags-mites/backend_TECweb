namespace Backend.DTOs.AccountType
{
    public class AccountTypeToEditDTO
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public string? Description { get; set; }
    }
}