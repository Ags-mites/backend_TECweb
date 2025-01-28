using Backend.Entities;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly IWebHostEnvironment _env;

        public SeedController(IAccountRepository accountRepository, IWebHostEnvironment env, IAccountTypeRepository accountTypeRepository)
        {
            _accountRepository = accountRepository;
            _env = env;
            _accountTypeRepository = accountTypeRepository;
        }

        [HttpGet("seed-accounts")]
        public async Task<IActionResult> SeedAccounts()
        {
            var dataFilePath = Path.Combine(_env.ContentRootPath, "data/seedData.json");

            if (!System.IO.File.Exists(dataFilePath))
            {
                return NotFound($"El archivo {dataFilePath} no existe.");
            }

            var jsonData = await System.IO.File.ReadAllTextAsync(dataFilePath);
            var seedData = JsonSerializer.Deserialize<SeedData>(jsonData);

            if (seedData?.Accounts == null || !seedData.Accounts.Any())
            {
                return BadRequest("El archivo JSON no contiene datos válidos.");
            }

            var existingAccounts = await _accountRepository.GetAllAsync();
            foreach (var account in existingAccounts)
            {
                await _accountRepository.DeleteAsync(account);
            }

            foreach (var account in seedData.Accounts)
            {
                var newAccount = new Account
                {
                    Code = account.Code,
                    Name = account.Name,
                    Status = account.Status,
                    Description = account.Description,
                    AccountTypeId = account.AccountTypeId,
                    CreatedAt = DateTime.Now
                };
                await _accountRepository.AddAsync(newAccount);
            }

            return Ok("Datos de prueba para Account insertados correctamente.");
        }

        [HttpGet("seed-accountTypes")]
        public async Task<IActionResult> SeedAccountTypes()
        {
            var dataFilePath = Path.Combine(_env.ContentRootPath, "data/seedData.json");

            if (!System.IO.File.Exists(dataFilePath))
            {
                return NotFound($"El archivo {dataFilePath} no existe.");
            }

            var jsonData = await System.IO.File.ReadAllTextAsync(dataFilePath);
            var seedData = JsonSerializer.Deserialize<SeedData>(jsonData);

            if (seedData?.AccountsType == null || !seedData.AccountsType.Any())
            {
                return BadRequest("El archivo JSON no contiene datos válidos.");
            }

            var existingAccountTypes = await _accountTypeRepository.GetAllAsync();
            foreach (var accountType in existingAccountTypes)
            {
                await _accountTypeRepository.DeleteAsync(accountType);
            }

            foreach (var accountType in seedData.AccountsType)
            {
                var newAccountType = new AccountType
                {
                    Code = accountType.Code,
                    Name = accountType.Name,
                    Status = accountType.Status,
                    Description = accountType.Description,
                    CreatedAt = DateTime.Now
                };
                await _accountTypeRepository.AddAsync(newAccountType);
            }

            return Ok("Datos de prueba para Account insertados correctamente.");
        }
    }

    public class SeedData
    {
        public List<Account>? Accounts { get; set; }
        public List<AccountType>? AccountsType { get; set; }
    }

}
