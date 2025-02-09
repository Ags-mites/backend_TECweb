using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.InvoiceDetail;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository; // Cambiado a repositorio de detalles de factura
        private readonly IMapper _mapper;

        public InvoiceDetailController(IInvoiceDetailRepository invoiceDetailRepository, IMapper mapper)
        {
            _invoiceDetailRepository = invoiceDetailRepository; // Inyección del repositorio de detalles de factura
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllInvoiceDetails() // Cambiado el nombre del método
        {
            var invoiceDetails = await _invoiceDetailRepository.GetAllAsync(); // Obtiene una lista de detalles de factura
            var invoiceDetailsDto = _mapper.Map<List<Dtos.InvoiceDetailToListDTO>>(invoiceDetails); // Mapea de InvoiceDetail a InvoiceDetailToListDTO
            return Ok(invoiceDetailsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id); // Cambiado a detalle de factura
            if (invoiceDetail == null)
            {
                return NotFound("Detalle de factura no encontrado");
            }
            var invoiceDetailDto = _mapper.Map<Dtos.InvoiceDetailToListDTO>(invoiceDetail); // Mapea detalle de factura a DTO
            return Ok(invoiceDetailDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.InvoiceDetailToCreateDTO invoiceDetailToCreateDTO)
        {
            var invoiceDetailToCreate = _mapper.Map<InvoiceDetail>(invoiceDetailToCreateDTO); // Mapea DTO a entidad InvoiceDetail
            var invoiceDetailCreated = await _invoiceDetailRepository.AddAsync(invoiceDetailToCreate); // Agrega el detalle de factura
            var invoiceDetailCreateDTO = _mapper.Map<Dtos.InvoiceDetailToListDTO>(invoiceDetailCreated); // Mapea el detalle de factura creado a DTO
            return Ok(invoiceDetailCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.InvoiceDetailToEditDTO invoiceDetailToEditDTO)
        {
            if (id != invoiceDetailToEditDTO.Id)
            {
                return BadRequest("Error en los datos de entrada");
            }
            var invoiceDetailToUpdate = await _invoiceDetailRepository.GetByIdAsync(id);
            if (invoiceDetailToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(invoiceDetailToEditDTO, invoiceDetailToUpdate); // Mapea el DTO a la entidad existente
            var updated = await _invoiceDetailRepository.UpdateAsync(id, invoiceDetailToUpdate);
            if (!updated)
            {
                return NoContent();
            }
            var invoiceDetail = await _invoiceDetailRepository.GetByIdAsync(id);
            var invoiceDetailDto = _mapper.Map<Dtos.InvoiceDetailToListDTO>(invoiceDetail); // Mapea el detalle de factura actualizado a DTO
            return Ok(invoiceDetailDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceDetailToDelete = await _invoiceDetailRepository.GetByIdAsync(id);

            if (invoiceDetailToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _invoiceDetailRepository.DeleteAsync(invoiceDetailToDelete);

            if (!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}