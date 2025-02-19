using Microsoft.AspNetCore.Mvc;
using Backend.Persistence.Interfaces;
using Backend.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository invoiceRepository, IInvoiceDetailRepository invoiceDetailRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInvoicesWithDetails()
        {
            var invoices = await _invoiceRepository
                .GetQueryable()
                .Include(i => i.Details)
                .ToListAsync();

            var invoicesDto = _mapper.Map<List<Backend.DTOs.Invoice.InvoiceToListDTO>>(invoices);
            return Ok(invoicesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceRepository
                .GetQueryable()
                .Include(i => i.Details)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            var invoiceDto = _mapper.Map<Backend.DTOs.Invoice.InvoiceToListDTO>(invoice);
            return Ok(invoiceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Backend.DTOs.Invoice.InvoiceToCreateDTO invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var invoice = _mapper.Map<Invoice>(invoiceDto);
            invoice.Details = [];

            var createdInvoice = await _invoiceRepository.AddAsync(invoice);

            if (invoiceDto.invoiceDetails?.Any() == true)
            {
                var invoiceDetails = _mapper.Map<List<InvoiceDetail>>(
                    invoiceDto.invoiceDetails
                );
                foreach (var detail in invoiceDetails)
                {
                    detail.InvoiceId = createdInvoice.Id;
                }
                await _invoiceDetailRepository.AddAll(invoiceDetails);
            }

            return await GetById(createdInvoice.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Backend.DTOs.Invoice.InvoiceToEditDTO invoiceDto)
        {
            if (id != invoiceDto.Id)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var invoiceToUpdate = await _invoiceRepository.GetQueryable()
    .Include(i => i.Details)
    .FirstOrDefaultAsync(i => i.Id == id);

            if (invoiceToUpdate == null)
                return NotFound("Factura no encontrada.");

            _mapper.Map(invoiceDto, invoiceToUpdate);

            var newDetailsIds = invoiceDto.invoiceDetails?.Select(d => d.Id).ToList() ?? new List<int>();

            // Se eliminan los detalles que ya no están presentes en el DTO
            var detailsToRemove = invoiceToUpdate.Details
                .Where(detail => !newDetailsIds.Contains(detail.Id))
                .ToList();

            foreach (var detail in detailsToRemove)
            {
                invoiceToUpdate.Details.Remove(detail);
            }

            // Se actualizan los detalles existentes y se agregan los nuevos
            foreach (var detailDto in invoiceDto.invoiceDetails)
            {
                var existingDetail = invoiceToUpdate.Details.FirstOrDefault(d => d.Id == detailDto.Id);
                if (existingDetail != null)
                {
                    _mapper.Map(detailDto, existingDetail);
                    //existingDetail.UpdatedAt = DateTime.UtcNow; // Remove this line as UpdatedAt does not exist
                }
                else
                {
                    var newDetail = _mapper.Map<InvoiceDetail>(detailDto);
                    newDetail.InvoiceId = id;
                    // Opcional: establecer CreatedAt si es necesario
                    invoiceToUpdate.Details.Add(newDetail);
                }
            }

            var updated = await _invoiceRepository.UpdateAsync(id, invoiceToUpdate);
            if (!updated)
                return StatusCode(500, "Error al actualizar la factura.");

            var fullInvoice = await _invoiceRepository.GetQueryable()
                .Include(i => i.Details)
                .FirstOrDefaultAsync(i => i.Id == id);

            var invoiceDtoResponse = _mapper.Map<Backend.DTOs.Invoice.InvoiceToListDTO>(fullInvoice);
            return Ok(invoiceDtoResponse);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null) return NotFound();

            await _invoiceDetailRepository.DeleteAsync(id);
            await _invoiceRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
