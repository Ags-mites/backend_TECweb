using System.Data;
using AutoMapper;
using Backend.DTOs.PayrollDetail;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.PayrollDetail;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PayrollDetailController : ControllerBase
    {
        private readonly IPayrollDetailRepository _PayrollDetailRepository;
        private readonly IMapper _mapper;

        public PayrollDetailController(IPayrollDetailRepository PayrollDetailRepository, IMapper mapper)
        {
            _PayrollDetailRepository = PayrollDetailRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetPayrollDetail()
        {
            var PayrollDetail =  await _PayrollDetailRepository.GetAllAsync();
            var PayrollDetailDto = _mapper.Map<List<Dtos.PayrollDetailToListDTO>>(PayrollDetail);
            return Ok(PayrollDetailDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var PayrollDetail =  await _PayrollDetailRepository.GetByIdAsync(id);
            var PayrollDetailDto = _mapper.Map<Dtos.PayrollDetailToListDTO>(PayrollDetail);
            return Ok(PayrollDetailDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.PayrollDetailToCreateDTO PayrollDetailToCreateDTO)
        {
            var PayrollDetailToCreate = _mapper.Map<PayrollDetail>(PayrollDetailToCreateDTO);
            PayrollDetailToCreate.CreatedAt = DateTime.Now;
            var PayrollDetailCreated = await _PayrollDetailRepository.AddAsync(PayrollDetailToCreate);
            var PayrollDetailCreateDTO = _mapper.Map<Dtos.PayrollDetailToListDTO>(PayrollDetailCreated);
            return Ok(PayrollDetailCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.PayrollDetailToEditDTO PayrollDetailToEditDTO)
        {
            if(id != PayrollDetailToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var PayrollDetailToUpdate = await _PayrollDetailRepository.GetByIdAsync(id);
            if(PayrollDetailToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(PayrollDetailToEditDTO,PayrollDetailToUpdate);
            PayrollDetailToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _PayrollDetailRepository.UpdateAsync( id ,PayrollDetailToUpdate);
            if(!updated){
                return NoContent();
            }
            var PayrollDetail = await _PayrollDetailRepository.GetByIdAsync(id);
            var PayrollDetailDTO = _mapper.Map<Dtos.PayrollDetailToListDTO>(PayrollDetail);
            return Ok(PayrollDetailDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var PayrollDetailToDelete = await _PayrollDetailRepository.GetByIdAsync(id);

            if(PayrollDetailToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _PayrollDetailRepository.DeleteAsync(PayrollDetailToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}