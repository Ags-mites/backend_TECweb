using System.Data;
using AutoMapper;
using Backend.DTOs.CabeceraCXC;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.CabeceraCXC;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CabeceraCXCController : ControllerBase
    {
        private readonly ICabeceraCXCRepository _CabeceraCXCRepository;
        private readonly IMapper _mapper;

        public CabeceraCXCController(ICabeceraCXCRepository CabeceraCXCRepository, IMapper mapper)
        {
            _CabeceraCXCRepository = CabeceraCXCRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCabeceraCXC()
        {
            var CabeceraCXC =  await _CabeceraCXCRepository.GetAllAsync();
            var CabeceraCXCDto = _mapper.Map<List<Dtos.CabeceraCXCToListDTO>>(CabeceraCXC);
            return Ok(CabeceraCXCDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var CabeceraCXC =  await _CabeceraCXCRepository.GetByIdAsync(id);
            var CabeceraCXCDto = _mapper.Map<Dtos.CabeceraCXCToListDTO>(CabeceraCXC);
            return Ok(CabeceraCXCDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.CabeceraCXCToCreateDTO CabeceraCXCToCreateDTO)
        {
            var CabeceraCXCToCreate = _mapper.Map<CabeceraCXC>(CabeceraCXCToCreateDTO);
           // CabeceraCXCToCreate.CreatedAt = DateTime.Now;
            var CabeceraCXCCreated = await _CabeceraCXCRepository.AddAsync(CabeceraCXCToCreate);
            var CabeceraCXCCreateDTO = _mapper.Map<Dtos.CabeceraCXCToListDTO>(CabeceraCXCCreated);
            return Ok(CabeceraCXCCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.CabeceraCXCToEditDTO CabeceraCXCToEditDTO)
        {
            if(id != CabeceraCXCToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var CabeceraCXCToUpdate = await _CabeceraCXCRepository.GetByIdAsync(id);
            if(CabeceraCXCToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(CabeceraCXCToEditDTO,CabeceraCXCToUpdate);
           // CabeceraCXCToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _CabeceraCXCRepository.UpdateAsync( id ,CabeceraCXCToUpdate);
            if(!updated){
                return NoContent();
            }
            var CabeceraCXC = await _CabeceraCXCRepository.GetByIdAsync(id);
            var CabeceraCXCDTO = _mapper.Map<Dtos.CabeceraCXCToListDTO>(CabeceraCXC);
            return Ok(CabeceraCXCDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var CabeceraCXCToDelete = await _CabeceraCXCRepository.GetByIdAsync(id);

            if(CabeceraCXCToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _CabeceraCXCRepository.DeleteAsync(CabeceraCXCToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}