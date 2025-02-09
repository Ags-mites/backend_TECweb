namespace Backend.DTOs.AccountType
{
    public class AccountTypeToCreateDTO
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public string? Description { get; set; }
    }
}