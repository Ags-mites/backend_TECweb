using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.CiudadEntrFac;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CiudadEntrFacController : ControllerBase
    {
        private readonly ICiudadEntrFacRepository _ciudadEntrFacRepository;
        private readonly IMapper _mapper;

        public CiudadEntrFacController(ICiudadEntrFacRepository ciudadEntrFacRepository, IMapper mapper)
        {
            _ciudadEntrFacRepository = ciudadEntrFacRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCiudadEntrFacs()
        {
            var ciudad =  await _ciudadEntrFacRepository.GetAllAsync();
            var ciudadDto = _mapper.Map<List<Dtos.CiudadEntrFacToListDTO>>(ciudad);
            return Ok(ciudadDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ciudad =  await _ciudadEntrFacRepository.GetByIdAsync(id);
            var ciudadDto = _mapper.Map<Dtos.CiudadEntrFacToListDTO>(ciudad);
            return Ok(ciudadDto);
        }

        // [HttpPost]
        // public async Task <IActionResult> Post(Dtos.ClientsFacToCreateDTO clientsFacToCreateDTO)
        // {
        //     var clientsFacToCreate = _mapper.Map<ClientsFac>(clientsFacToCreateDTO);
        //     clientsFacToCreate.TimeCli = DateTime.Now;
        //     var clientsFacCreated = await _ciudadEntrFacRepository.AddAsync(clientsFacToCreate);
        //     var clientsFacCreateDTO = _mapper.Map<Dtos.ClientsFacToListDTO>(clientsFacCreated);
        //     return Ok(clientsFacCreateDTO);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put (int id, Dtos.ClientsFacToEditDTO clientsFacToEditDTOO)
        // {
        //     if(id != clientsFacToEditDTOO.Id)
        //     {
        //         return  BadRequest("Error en los datos de entrada");
        //     }
        //     var clientsFacToUpdate = await _ciudadEntrFacRepository.GetByIdAsync(id);
        //     if(clientsFacToUpdate is null)
        //     {
        //         return BadRequest("Id no encontrado");
        //     }
            
        //     _mapper.Map(clientsFacToEditDTOO,clientsFacToUpdate);
        //     clientsFacToUpdate.UpdatedAt = DateTime.Now;
        //     var updated = await _ciudadEntrFacRepository.UpdateAsync( id ,clientsFacToUpdate);
        //     if(!updated){
        //         return NoContent();
        //     }
        //     var clients = await _ciudadEntrFacRepository.GetByIdAsync(id);
        //     var clientsDto = _mapper.Map<Dtos.ClientsFacToListDTO>(clients);
        //     return Ok(clientsDto);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var ciudadEntrFacToDelete = await _ciudadEntrFacRepository.GetByIdAsync(id);

            if(ciudadEntrFacToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _ciudadEntrFacRepository.DeleteAsync(ciudadEntrFacToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}