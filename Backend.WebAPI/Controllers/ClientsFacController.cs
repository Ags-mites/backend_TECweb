using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.ClientsFac;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsFacController : ControllerBase
    {
        private readonly IClientsFacRepository _clientsFacRepository;
        private readonly IMapper _mapper;

        public ClientsFacController(IClientsFacRepository clientsFacRepository, IMapper mapper)
        {
            _clientsFacRepository = clientsFacRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllclientsFacs()
        {
            var clients =  await _clientsFacRepository.GetAllAsync();
            var clientsDto = _mapper.Map<List<Dtos.ClientsFacToListDTO>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var clients =  await _clientsFacRepository.GetByIdAsync(id);
            var clientsDto = _mapper.Map<Dtos.ClientsFacToListDTO>(clients);
            return Ok(clientsDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.ClientsFacToCreateDTO clientsFacToCreateDTO)
        {
            var clientsFacToCreate = _mapper.Map<ClientsFac>(clientsFacToCreateDTO);
            clientsFacToCreate.TimeCli = DateTime.Now;
            var clientsFacCreated = await _clientsFacRepository.AddAsync(clientsFacToCreate);
            var clientsFacCreateDTO = _mapper.Map<Dtos.ClientsFacToListDTO>(clientsFacCreated);
            return Ok(clientsFacCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.ClientsFacToEditDTO clientsFacToEditDTOO)
        {
            if(id != clientsFacToEditDTOO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var clientsFacToUpdate = await _clientsFacRepository.GetByIdAsync(id);
            if(clientsFacToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(clientsFacToEditDTOO,clientsFacToUpdate);
            clientsFacToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _clientsFacRepository.UpdateAsync( id ,clientsFacToUpdate);
            if(!updated){
                return NoContent();
            }
            var clients = await _clientsFacRepository.GetByIdAsync(id);
            var clientsDto = _mapper.Map<Dtos.ClientsFacToListDTO>(clients);
            return Ok(clientsDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var clientsFacToDelete = await _clientsFacRepository.GetByIdAsync(id);

            if(clientsFacToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _clientsFacRepository.DeleteAsync(clientsFacToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}