using System.Data;
using AutoMapper;
using Backend.DTOs.ReasonAdmission;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.ReasonAdmission;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NReasonAdmissionController : ControllerBase
    {
        private readonly  IReasonAdmissionRepository _reasonAdmissionRepository;
        private readonly IMapper _mapper;

        public NReasonAdmissionController(IReasonAdmissionRepository reasonAdmissionRepository, IMapper mapper)
        {
            _reasonAdmissionRepository = reasonAdmissionRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllResonAdmission()
        {
            var reasonadmission =  await _reasonAdmissionRepository.GetAllAsync();
            var reasonadmissionDto = _mapper.Map<List<Dtos.ReasonAdmissionToListDTO>>(reasonadmission);
            return Ok(reasonadmissionDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var reasonadmission =  await _reasonAdmissionRepository.GetByIdAsync(id);
            var reasonadmissionDto = _mapper.Map<Dtos.ReasonAdmissionToListDTO>(reasonadmission);
            return Ok(reasonadmissionDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.ReasonAdmissionToCreateDTO reasonAdmissionToCreateDTO)
        {
            var reasonAdmissionToCreate = _mapper.Map<ReasonAdmission>(reasonAdmissionToCreateDTO);
            Console.WriteLine(reasonAdmissionToCreate);            
            reasonAdmissionToCreate.CreatedAt = DateTime.Now;
            Console.WriteLine(reasonAdmissionToCreate.CreatedAt);            
            var reasonadmissionCreated = await _reasonAdmissionRepository.AddAsync(reasonAdmissionToCreate);
            var reasonadmissionCreateDTO = _mapper.Map<Dtos.ReasonAdmissionToListDTO>(reasonadmissionCreated);
            return Ok(reasonadmissionCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.ReasonAdmissionToEditDTO reasonAdmissionToEditDTO)
        {
            if(id != reasonAdmissionToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var reasonAdmissionToUpdate = await _reasonAdmissionRepository.GetByIdAsync(id);
            if(reasonAdmissionToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(reasonAdmissionToEditDTO,reasonAdmissionToUpdate);
            reasonAdmissionToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _reasonAdmissionRepository.UpdateAsync( id ,reasonAdmissionToUpdate);
            if(!updated){
                return NoContent();
            }
            var reasonadmission = await _reasonAdmissionRepository.GetByIdAsync(id);
            var reasonDTO = _mapper.Map<Dtos.ReasonAdmissionToListDTO>(reasonadmission);
            return Ok(reasonDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var reasonadmissionToDelete = await _reasonAdmissionRepository.GetByIdAsync(id);

            if(reasonadmissionToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _reasonAdmissionRepository.DeleteAsync(reasonadmissionToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}