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
    public class CAccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CAccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllAccounts()
        {
            var accounts =  await _accountRepository.GetAllAsync();
            var accountDto = _mapper.Map<List<Dtos.AccountToListDTO>>(accounts);
            return Ok(accountDto);
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
            var accountToCreate = _mapper.Map<Account>(accountToCreateDTO);
            accountToCreate.CreatedAt = DateTime.Now;
            var accountCreated = await _accountRepository.AddAsync(accountToCreate);
            var accountCreateDTO = _mapper.Map<Dtos.AccountToListDTO>(accountCreated);
            return Ok(accountCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.AccountToEditDTO accountToEditDTO)
        {
            if(id != accountToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var accountToUpdate = await _accountRepository.GetByIdAsync(id);
            if(accountToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(accountToEditDTO,accountToUpdate);
            accountToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _accountRepository.UpdateAsync( id ,accountToUpdate);
            if(!updated){
                return NoContent();
            }
            var account = await _accountRepository.GetByIdAsync(id);
            var accountDTO = _mapper.Map<Dtos.AccountToListDTO>(account);
            return Ok(accountDTO);
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