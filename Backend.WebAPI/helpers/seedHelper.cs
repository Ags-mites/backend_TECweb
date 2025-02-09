using System.Text.Json;
using Backend.Entities;

namespace Backend.WebAPI.Helpers
{
    public static class SeedHelper
    {
        public static List<Account> GetAccountsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"El archivo {filePath} no fue encontrado.");

            var jsonData = File.ReadAllText(filePath);
            var seedData = JsonSerializer.Deserialize<SeedData>(jsonData);

            if (seedData == null || seedData.Accounts == null)
                throw new InvalidOperationException("El archivo JSON no contiene datos válidos.");

            return seedData.Accounts;
        }
    }

    public class SeedData
    {
        public List<Account>? Accounts { get; set; }
    }
}
