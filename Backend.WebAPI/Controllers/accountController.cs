using System.Data;
using AutoMapper;
using Backend.DTOs.Account;
using Backend.DTOs.AccountType;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Account;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public accountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAccountsWithTypes()
        {
            var accounts = await _accountRepository
                .GetQueryable()
                .Include(a => a.AccountType)
                .ToListAsync();

            var accountsWithTypesDto = _mapper.Map<List<AccountToListDTO>>(accounts);
            return Ok(accountsWithTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var account =  await _accountRepository.GetByIdAsync(id);
            var accountDto = _mapper.Map<Dtos.AccountToListDTO>(account);
            return Ok(accountDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.AccountToCreateDTO accountToCreateDTO)
        {
            var account = _mapper.Map<Account>(accountToCreateDTO);
            account.CreatedAt = DateTime.Now;
            var createdAccount = await _accountRepository.AddAsync(account);
            var fullAccount = await _accountRepository
                .GetQueryable()
                .Include(a => a.AccountType)
                .FirstOrDefaultAsync(a => a.Id == createdAccount.Id);
            var accountDto = _mapper.Map<AccountToListDTO>(fullAccount);
            return CreatedAtAction(nameof(GetAllAccountsWithTypes), new { id = accountDto.Id }, accountDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.AccountToEditDTO accountToEditDTO)
        {
            if (id != accountToEditDTO.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el objeto.");
            }

            var accountToUpdate = await _accountRepository.GetByIdAsync(id);

            if (accountToUpdate == null)
            {
                return NotFound("La cuenta no fue encontrada.");
            }

            _mapper.Map(accountToEditDTO, accountToUpdate);
            accountToUpdate.UpdatedAt = DateTime.Now;

            var updated = await _accountRepository.UpdateAsync(id, accountToUpdate);

            if (!updated)
            {
                return StatusCode(500, "Error al actualizar la cuenta.");
            }

            var fullAccount = await _accountRepository
                .GetQueryable()
                .Include(a => a.AccountType)
                .FirstOrDefaultAsync(a => a.Id == id);

            var accountDto = _mapper.Map<AccountToListDTO>(fullAccount);

            return Ok(accountDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var accountToDelete = await _accountRepository.GetByIdAsync(id);

            if(accountToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _accountRepository.DeleteAsync(accountToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}