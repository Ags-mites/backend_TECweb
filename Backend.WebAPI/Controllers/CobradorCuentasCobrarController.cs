using System.Data;
using AutoMapper;
using Backend.DTOs.CobradorCuentasCobrar;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.CobradorCuentasCobrar;

namespace Backend.WebAPI.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CobradorCuentasCobrarController : ControllerBase{
         private readonly ICobradorCuentasCobrarRepository _CobradorCuentasCobrarRepository;
        private readonly IMapper _mapper;

        public CobradorCuentasCobrarController(ICobradorCuentasCobrarRepository CobradorCuentasCobrarRepository, IMapper mapper)
        {
            _CobradorCuentasCobrarRepository = CobradorCuentasCobrarRepository;
            _mapper=mapper;
        } 
              
        [HttpGet("all")]
        public async Task<ActionResult> GetAllCobradorCuentasCobrar()
        {
            var CobradorCuentasCobrar =  await _CobradorCuentasCobrarRepository.GetAllAsync();
            var CobradorCuentasCobrarDto = _mapper.Map<List<Dtos.CobradorCuentasCobrarToListDTO>>(CobradorCuentasCobrar);
            return Ok(CobradorCuentasCobrarDto);
        }     
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var CobradorCuentasCobrar =  await _CobradorCuentasCobrarRepository.GetByIdAsync(id);
            var CobradorCuentasCobrarDto = _mapper.Map<Dtos.CobradorCuentasCobrarToListDTO>(CobradorCuentasCobrar);
            return Ok(CobradorCuentasCobrarDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.CobradorCuentasCobrarToCreateDTO CobradorCuentasCobrarToCreateDTO)
        {
            var CobradorCuentasCobrarToCreate = _mapper.Map<CobradorCuentasCobrar>(CobradorCuentasCobrarToCreateDTO);
            var CobradorCuentasCobrarCreated = await _CobradorCuentasCobrarRepository.AddAsync(CobradorCuentasCobrarToCreate);
            var CobradorCuentasCobrarCreateDTO = _mapper.Map<Dtos.CobradorCuentasCobrarToListDTO>(CobradorCuentasCobrarCreated);
            return Ok(CobradorCuentasCobrarCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.CobradorCuentasCobrarToEditDTO CobradorCuentasCobrarToEditDTO)
        {
            if(id != CobradorCuentasCobrarToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var CobradorCuentasCobrarToUpdate = await _CobradorCuentasCobrarRepository.GetByIdAsync(id);
            if(CobradorCuentasCobrarToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(CobradorCuentasCobrarToEditDTO,CobradorCuentasCobrarToUpdate);
            var updated = await _CobradorCuentasCobrarRepository.UpdateAsync( id ,CobradorCuentasCobrarToUpdate);
            if(!updated){
                return NoContent();
            }
            var CobradorCuentasCobrar = await _CobradorCuentasCobrarRepository.GetByIdAsync(id);
            var CobradorCuentasCobrarDTO = _mapper.Map<Dtos.CobradorCuentasCobrarToListDTO>(CobradorCuentasCobrar);
            return Ok(CobradorCuentasCobrarDTO);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var CobradorCuentasCobrarToDelete = await _CobradorCuentasCobrarRepository.GetByIdAsync(id);

            if(CobradorCuentasCobrarToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _CobradorCuentasCobrarRepository.DeleteAsync(CobradorCuentasCobrarToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}
