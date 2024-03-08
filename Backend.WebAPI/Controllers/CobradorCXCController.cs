using System.Data;
using AutoMapper;
using Backend.DTOs.CobradorCXC;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.CobradorCXC;

namespace Backend.WebAPI.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CobradorCXCController : ControllerBase{
         private readonly ICobradorCXCRepository _cobradorcxcRepository;
        private readonly IMapper _mapper;

        public CobradorCXCController(ICobradorCXCRepository cobradorcxcRepository, IMapper mapper)
        {
            _cobradorcxcRepository = cobradorcxcRepository;
            _mapper=mapper;
        } 
              
        [HttpGet("all")]
        public async Task<ActionResult> GetAllCobradorCXC()
        {
            var cobrador =  await _cobradorcxcRepository.GetAllAsync();
            var cobradorDto = _mapper.Map<List<Dtos.CobradorCXCToListDTO>>(cobrador);
            return Ok(cobradorDto);
        }     
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var cobrador =  await _cobradorcxcRepository.GetByIdAsync(id);
            var cobradorDto = _mapper.Map<Dtos.CobradorCXCToListDTO>(cobrador);
            return Ok(cobradorDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.CobradorCXCToCreateDTO cobradorcxcToCreateDTO)
        {
            var cobradorToCreate = _mapper.Map<CobradorCXC>(cobradorcxcToCreateDTO);
            cobradorToCreate.CreatedAt = DateTime.Now;
            var cobradorcxcCreated = await _cobradorcxcRepository.AddAsync(cobradorToCreate);
            var cobradorcxcCreateDTO = _mapper.Map<Dtos.CobradorCXCToListDTO>(cobradorcxcCreated);
            return Ok(cobradorcxcCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.CobradorCXCToEditDTO cobradorCXCToEditDTO)
        {
            if(id != cobradorCXCToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var cobradorToUpdate = await _cobradorcxcRepository.GetByIdAsync(id);
            if(cobradorToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(cobradorCXCToEditDTO,cobradorToUpdate);
            cobradorToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _cobradorcxcRepository.UpdateAsync( id ,cobradorToUpdate);
            if(!updated){
                return NoContent();
            }
            var cobrador = await _cobradorcxcRepository.GetByIdAsync(id);
            var cobradorDTO = _mapper.Map<Dtos.CobradorCXCToListDTO>(cobrador);
            return Ok(cobradorDTO);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var cobradorcxcToDelete = await _cobradorcxcRepository.GetByIdAsync(id);

            if(cobradorcxcToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _cobradorcxcRepository.DeleteAsync(cobradorcxcToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }







    }
}
