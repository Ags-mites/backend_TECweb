namespace Backend.DTOs.Account
{
    public class AccountToCreateDTO
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Status { get; set; }
        public string? Description { get; set; }

        public int AccountTypeId { get; set; }
        
    }
}