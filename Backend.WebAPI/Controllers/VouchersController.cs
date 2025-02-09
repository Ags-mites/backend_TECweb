using System.Data;
using AutoMapper;
using Backend.DTOs.Voucher;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Voucher;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/vouchers")]
    [ApiController]
    public class voucherController : ControllerBase
    {
        private readonly IVoucherRespository _voucherRepository;
        private readonly IMapper _mapper;

        public voucherController(IVoucherRespository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper=mapper;
        }

         [HttpGet("all")]
        public async Task<ActionResult> GetAllVoucher()
        {
            var vouchers =  await _voucherRepository.GetAllAsync();
            var voucherDto = _mapper.Map<List<Dtos.VoucherToListDTO>>(vouchers);
            return Ok(voucherDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var voucher =  await _voucherRepository.GetByIdAsync(id);
            var voucherDto = _mapper.Map<Dtos.VoucherToListDTO>(voucher);
            return Ok(voucherDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.VoucherToCreateDTO voucherToCreateDTO)
        {
            var voucherToCreate = _mapper.Map<Voucher>(voucherToCreateDTO);
            voucherToCreate.CreatedAt = DateTime.Now;
            var voucherCreated = await _voucherRepository.AddAsync(voucherToCreate);
            var voucherCreateDTO = _mapper.Map<Dtos.VoucherToListDTO>(voucherCreated);
            return Ok(voucherCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.VoucherToEditDTO voucherToEditDTO)
        {
            if(id != voucherToEditDTO.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var voucherToUpdate = await _voucherRepository.GetByIdAsync(id);
            if(voucherToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(voucherToEditDTO,voucherToUpdate);
            voucherToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _voucherRepository.UpdateAsync( id ,voucherToUpdate);
            if(!updated){
                return NoContent();
            }
            var voucher = await _voucherRepository.GetByIdAsync(id);
            var voucherDTO = _mapper.Map<Dtos.VoucherToListDTO>(voucher);
            return Ok(voucherDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var voucherToDelete = await _voucherRepository.GetByIdAsync(id);

            if(voucherToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _voucherRepository.DeleteAsync(voucherToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}