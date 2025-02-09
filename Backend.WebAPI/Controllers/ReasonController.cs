using System.Data;
using AutoMapper;
using Backend.DTOs.Reason;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Reason;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReasonController : ControllerBase
    {
        private readonly  IReasonRepository _reasonRepository;
        private readonly IMapper _mapper;

        public ReasonController(IReasonRepository reasonRepository, IMapper mapper)
        {
            _reasonRepository = reasonRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllResonAdmission()
        {
            var reason =  await _reasonRepository.GetAllAsync();
            var reasonDto = _mapper.Map<List<Dtos.ReasonToListDTO>>(reason);
            return Ok(reasonDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var reason =  await _reasonRepository.GetByIdAsync(id);
            var reasonDto = _mapper.Map<Dtos.ReasonToListDTO>(reason);
            return Ok(reasonDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.ReasonToCreateDTO reasonToCreateDTO)
        {
            var reasonToCreate = _mapper.Map<Reasons>(reasonToCreateDTO);
            Console.WriteLine(reasonToCreate);            
            reasonToCreate.CreatedAt = DateTime.Now;
            Console.WriteLine(reasonToCreate.CreatedAt);            
            var reasonCreated = await _reasonRepository.AddAsync(reasonToCreate);
            var reasonCreateDTO = _mapper.Map<Dtos.ReasonToListDTO>(reasonCreated);
            return Ok(reasonCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.ReasonToEditDTO reasonToEditDTO)
        {
            if(id != reasonToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var reasonToUpdate = await _reasonRepository.GetByIdAsync(id);
            if(reasonToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(reasonToEditDTO,reasonToUpdate);
            reasonToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _reasonRepository.UpdateAsync( id ,reasonToUpdate);
            if(!updated){
                return NoContent();
            }
            var reason = await _reasonRepository.GetByIdAsync(id);
            var reasonDTO = _mapper.Map<Dtos.ReasonToListDTO>(reason);
            return Ok(reasonDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var reasonToDelete = await _reasonRepository.GetByIdAsync(id);

            if(reasonToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _reasonRepository.DeleteAsync(reasonToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}