using System.Data;
using AutoMapper;
using Backend.DTOs.VoucherType;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.VoucherType;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VoucherTypeController : ControllerBase
    {
        private readonly IVoucherTypeRepository _voucherTypeRepository;
        private readonly IMapper _mapper;

        public VoucherTypeController(IVoucherTypeRepository voucherTypeRepository, IMapper mapper)
        {
            _voucherTypeRepository = voucherTypeRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllVoucherType()
        {
            var voucherTypes =  await _voucherTypeRepository.GetAllAsync();
            var voucherTypesDto = _mapper.Map<List<Dtos.VoucherTypeToListDTO>>(voucherTypes);
            return Ok(voucherTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var voucherType =  await _voucherTypeRepository.GetByIdAsync(id);
            var voucherTypeDto = _mapper.Map<Dtos.VoucherTypeToListDTO>(voucherType);
            return Ok(voucherTypeDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.VoucherTypeToCreateDTO voucherTypeToCreateDTO)
        {
            var voucherTypeToCreate = _mapper.Map<VoucherType>(voucherTypeToCreateDTO);
            voucherTypeToCreate.CreatedAt = DateTime.Now;
            var voucherTypeCreated = await _voucherTypeRepository.AddAsync(voucherTypeToCreate);
            var voucherTypeCreateDTO = _mapper.Map<Dtos.VoucherTypeToListDTO>(voucherTypeCreated);
            return Ok(voucherTypeCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.VoucherTypeToEditDTO voucherTypeToEditDTO)
        {
            if(id != voucherTypeToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var voucherTypeToUpdate = await _voucherTypeRepository.GetByIdAsync(id);
            if(voucherTypeToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(voucherTypeToEditDTO,voucherTypeToUpdate);
            voucherTypeToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _voucherTypeRepository.UpdateAsync( id ,voucherTypeToUpdate);
            if(!updated){
                return NoContent();
            }
            var voucher = await _voucherTypeRepository.GetByIdAsync(id);
            var voucherDTO = _mapper.Map<Dtos.VoucherTypeToListDTO>(voucher);
            return Ok(voucherDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var voucherToDelete = await _voucherTypeRepository.GetByIdAsync(id);

            if(voucherToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _voucherTypeRepository.DeleteAsync(voucherToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}