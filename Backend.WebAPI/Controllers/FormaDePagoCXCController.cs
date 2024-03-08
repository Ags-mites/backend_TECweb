using System.Data;
using AutoMapper;
using Backend.DTOs.FormaDePagoCXC;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.FormaDePagoCXC;

namespace Backend.WebAPI.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FormaDePagoCXCController : ControllerBase{
         private readonly IFormaDePagoCXCRepository _formaDePagocxcRepository;
        private readonly IMapper _mapper;

        public FormaDePagoCXCController(IFormaDePagoCXCRepository formaDePagocxcRepository, IMapper mapper)
        {
            _formaDePagocxcRepository = formaDePagocxcRepository;
            _mapper=mapper;
        } 
              
        [HttpGet("all")]
        public async Task<ActionResult> GetAllFormaDePagoCXC()
        {
            var formaPago =  await _formaDePagocxcRepository.GetAllAsync();
            var formaPagoDto = _mapper.Map<List<Dtos.FormaDePagoCXCToListDTO>>(formaPago);
            return Ok(formaPagoDto);
        }     
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var formaPago =  await _formaDePagocxcRepository.GetByIdAsync(id);
            var formaPagoDto = _mapper.Map<Dtos.FormaDePagoCXCToListDTO>(formaPago);
            return Ok(formaPagoDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.FormaDePagoCXCToCreateDTO formaDePagocxcToCreateDTO)
        {
            var formaDePagocxcToCreate = _mapper.Map<FormaDePagoCXC>(formaDePagocxcToCreateDTO);
            formaDePagocxcToCreate.CreatedAt = DateTime.Now;
            var formaDePagocxcCreated = await _formaDePagocxcRepository.AddAsync(formaDePagocxcToCreate);
            var formaDePagocxcCreateDTO = _mapper.Map<Dtos.FormaDePagoCXCToListDTO>(formaDePagocxcCreated);
            return Ok(formaDePagocxcCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.FormaDePagoCXCToEditDTO formaDePagoCXCToEditDTO)
        {
            if(id != formaDePagoCXCToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var formaPagoToUpdate = await _formaDePagocxcRepository.GetByIdAsync(id);
            if(formaPagoToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(formaDePagoCXCToEditDTO,formaPagoToUpdate);
            formaPagoToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _formaDePagocxcRepository.UpdateAsync( id ,formaPagoToUpdate);
            if(!updated){
                return NoContent();
            }
            var forma = await _formaDePagocxcRepository.GetByIdAsync(id);
            var formaDTO = _mapper.Map<Dtos.FormaDePagoCXCToListDTO>(forma);
            return Ok(formaDTO);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var formaDePagocxcToDelete = await _formaDePagocxcRepository.GetByIdAsync(id);

            if(formaDePagocxcToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _formaDePagocxcRepository.DeleteAsync(formaDePagocxcToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}



