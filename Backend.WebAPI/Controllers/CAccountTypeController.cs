using System.Data;
using AutoMapper;
using Backend.DTOs.AccountType;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.AccountType;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CAccountTypeController : ControllerBase
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly IMapper _mapper;

        public CAccountTypeController(IAccountTypeRepository accountTypeRepository, IMapper mapper)
        {
            _accountTypeRepository = accountTypeRepository;
            _mapper=mapper;
        }
        
        [HttpGet("all")]
        public async Task<ActionResult> GetAllAccountType()
        {
            var accountTypes =  await _accountTypeRepository.GetAllAsync();
            var accountTypeDto = _mapper.Map<List<Dtos.AccountTypeToListDTO>>(accountTypes);
            return Ok(accountTypeDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var accountType =  await _accountTypeRepository.GetByIdAsync(id);
            var accountTypeDto = _mapper.Map<Dtos.AccountTypeToListDTO>(accountType);
            return Ok(accountTypeDto);
        } 

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.AccountTypeToCreateDTO accountTypeToCreateDTO)
        {
            var accountTypeToCreate = _mapper.Map<AccountType>(accountTypeToCreateDTO);
            accountTypeToCreate.CreatedAt = DateTime.Now;
            var accountTypeCreated = await _accountTypeRepository.AddAsync(accountTypeToCreate);
            var accountTypeCreateDTO = _mapper.Map<Dtos.AccountTypeToListDTO>(accountTypeCreated);
            return Ok(accountTypeCreateDTO);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.AccountTypeToEditDTO accountTypeToEditDTO)
        {
            if(id != accountTypeToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var accountTypeToUpdate = await _accountTypeRepository.GetByIdAsync(id);
            if(accountTypeToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(accountTypeToEditDTO,accountTypeToUpdate);
            accountTypeToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _accountTypeRepository.UpdateAsync( id ,accountTypeToUpdate);
            if(!updated){
                return NoContent();
            }
            var accountType = await _accountTypeRepository.GetByIdAsync(id);
            var accountTypeDTO = _mapper.Map<Dtos.AccountTypeToListDTO>(accountType);
            return Ok(accountTypeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var accountTypeToDelete = await _accountTypeRepository.GetByIdAsync(id);

            if(accountTypeToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _accountTypeRepository.DeleteAsync(accountTypeToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        } 
    }
}