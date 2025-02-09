using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Invoice;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository; // Cambiado a repositorio de facturas
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository; // Inyección del repositorio de facturas
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllInvoices() // Cambiado el nombre del método
        {
            var invoices = await _invoiceRepository.GetAllAsync(); // Obtiene una lista de facturas
            var invoicesDto = _mapper.Map<List<Dtos.InvoiceToListDTO>>(invoices); // Mapea de Invoice a InvoiceToListDTO
            return Ok(invoicesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id); // Cambiado a factura
            if (invoice == null)
            {
                return NotFound("Factura no encontrada");
            }
            var invoiceDto = _mapper.Map<Dtos.InvoiceToListDTO>(invoice); // Mapea factura a DTO
            return Ok(invoiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.InvoiceToCreateDTO invoiceToCreateDTO)
        {
            var invoiceToCreate = _mapper.Map<Invoice>(invoiceToCreateDTO); // Mapea DTO a entidad Invoice
            var invoiceCreated = await _invoiceRepository.AddAsync(invoiceToCreate); // Agrega la factura
            var invoiceCreateDTO = _mapper.Map<Dtos.InvoiceToListDTO>(invoiceCreated); // Mapea la factura creada a DTO
            return Ok(invoiceCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.InvoiceToEditDTO invoiceToEditDTO)
        {
            if (id != invoiceToEditDTO.Id)
            {
                return BadRequest("Error en los datos de entrada");
            }
            var invoiceToUpdate = await _invoiceRepository.GetByIdAsync(id);
            if (invoiceToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(invoiceToEditDTO, invoiceToUpdate); // Mapea el DTO a la entidad existente
            var updated = await _invoiceRepository.UpdateAsync(id, invoiceToUpdate);
            if (!updated)
            {
                return NoContent();
            }
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            var invoiceDto = _mapper.Map<Dtos.InvoiceToListDTO>(invoice); // Mapea la factura actualizada a DTO
            return Ok(invoiceDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceToDelete = await _invoiceRepository.GetByIdAsync(id);

            if (invoiceToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _invoiceRepository.DeleteAsync(invoiceToDelete);

            if (!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}