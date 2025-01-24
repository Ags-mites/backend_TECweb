using System.Data;
using AutoMapper;
using Backend.DTOs.PayrollHeader;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.PayrollHeader;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NPayrollHeaderController : ControllerBase
    {
        private readonly IPayrollHeaderRepository _PayrollHeaderRepository;
        private readonly IMapper _mapper;

        public NPayrollHeaderController(IPayrollHeaderRepository PayrollHeaderRepository, IMapper mapper)
        {
            _PayrollHeaderRepository = PayrollHeaderRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetPayrollHeader()
        {
            var PayrollHeader =  await _PayrollHeaderRepository.GetAllAsync();
            var PayrollHeaderDto = _mapper.Map<List<Dtos.PayrollHeaderToListDTO>>(PayrollHeader);
            return Ok(PayrollHeaderDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var PayrollHeader =  await _PayrollHeaderRepository.GetByIdAsync(id);
            var PayrollHeaderDto = _mapper.Map<Dtos.PayrollHeaderToListDTO>(PayrollHeader);
            return Ok(PayrollHeaderDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.PayrollHeaderToCreateDTO PayrollHeaderToCreateDTO)
        {
            var PayrollHeaderToCreate = _mapper.Map<PayrollHeader>(PayrollHeaderToCreateDTO);
            PayrollHeaderToCreate.CreatedAt = DateTime.Now;
            var PayrollHeaderCreated = await _PayrollHeaderRepository.AddAsync(PayrollHeaderToCreate);
            var PayrollHeaderCreateDTO = _mapper.Map<Dtos.PayrollHeaderToListDTO>(PayrollHeaderCreated);
            return Ok(PayrollHeaderCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.PayrollHeaderToEditDTO PayrollHeaderToEditDTO)
        {
            if(id != PayrollHeaderToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var PayrollHeaderToUpdate = await _PayrollHeaderRepository.GetByIdAsync(id);
            if(PayrollHeaderToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(PayrollHeaderToEditDTO,PayrollHeaderToUpdate);
            PayrollHeaderToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _PayrollHeaderRepository.UpdateAsync( id ,PayrollHeaderToUpdate);
            if(!updated){
                return NoContent();
            }
            var PayrollHeader = await _PayrollHeaderRepository.GetByIdAsync(id);
            var PayrollHeaderDTO = _mapper.Map<Dtos.PayrollHeaderToListDTO>(PayrollHeader);
            return Ok(PayrollHeaderDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var PayrollHeaderToDelete = await _PayrollHeaderRepository.GetByIdAsync(id);

            if(PayrollHeaderToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _PayrollHeaderRepository.DeleteAsync(PayrollHeaderToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}