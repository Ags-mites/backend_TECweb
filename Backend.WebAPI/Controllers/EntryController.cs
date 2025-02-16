using Microsoft.AspNetCore.Mvc;
using Backend.Persistence.Interfaces;
using Backend.Entities;
using Backend.DTOs.EntryHeader;
using Backend.DTOs.EntryDetail;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/vouchers")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryHeaderRepository _entryHeaderRepository;
        private readonly IEntryDetailRepository _entryDetailRepository;
        private readonly IMapper _mapper;

        public EntryController(IEntryHeaderRepository entryHeaderRepository, IEntryDetailRepository entryDetailRepository, IMapper mapper)
        {
            _entryHeaderRepository = entryHeaderRepository;
            _entryDetailRepository = entryDetailRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEntryHeadersWithDetails()
        {
            var entrys = await _entryHeaderRepository
                .GetQueryable()
                .Include(eh => eh.EntryDetails)
                    .ThenInclude(ed => ed.Account)
                .ToListAsync();

            var entryWithDetailsDto = _mapper.Map<List<EntryHeaderToListDTO>>(entrys);
            return Ok(entryWithDetailsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _entryHeaderRepository
                .GetQueryable()
                .Include(eh => eh.EntryDetails)
                    .ThenInclude(ed => ed.Account)
                .FirstOrDefaultAsync(eh => eh.Id == id);

            if (entry == null) return NotFound();

            var entryDto = _mapper.Map<EntryHeaderToListDTO>(entry);
            return Ok(entryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EntryHeaderToCreateDTO entryHeaderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entryHeader = _mapper.Map<EntryHeader>(entryHeaderDto);
            entryHeader.EntryDetails = [];
            entryHeader.CreatedAt = DateTime.UtcNow;
            entryHeader.UpdatedAt = DateTime.UtcNow;

            var createdHeader = await _entryHeaderRepository.AddAsync(entryHeader);

            if (entryHeaderDto.EntryDetails?.Any() == true)
            {
                var entryDetails = _mapper.Map<List<EntryDetail>>(
                    entryHeaderDto.EntryDetails
                );
                foreach (var detail in entryDetails)
                {
                    detail.EntryHeaderId = createdHeader.Id;
                    detail.CreatedAt = DateTime.UtcNow;
                    detail.UpdatedAt = DateTime.UtcNow;
                }
                await _entryDetailRepository.AddAll(entryDetails);
            }

            var responseDto = _mapper.Map<EntryHeaderToListDTO>(createdHeader);
            return CreatedAtAction(nameof(GetById), new { id = createdHeader.Id }, responseDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EntryHeaderToEditDTO entryHeaderDto)
        {
            if (id != entryHeaderDto.Id)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var entryToUpdate = await _entryHeaderRepository.GetQueryable()
                .Include(eh => eh.EntryDetails)
                .FirstOrDefaultAsync(eh => eh.Id == id);

            if (entryToUpdate == null)
                return NotFound("El voucher no fue encontrado.");

            _mapper.Map(entryHeaderDto, entryToUpdate);
            entryToUpdate.UpdatedAt = DateTime.UtcNow;

            var newDetailsIds = entryHeaderDto.EntryDetails?.Select(d => d.Id).ToList() ?? new List<int>();

            var detailsToRemove = entryToUpdate.EntryDetails
                .Where(ed => !newDetailsIds.Contains(ed.Id))
                .ToList();

            foreach (var detail in detailsToRemove)
            {
                entryToUpdate.EntryDetails.Remove(detail);
            }

            foreach (var detailDto in entryHeaderDto.EntryDetails)
            {
                var existingDetail = entryToUpdate.EntryDetails.FirstOrDefault(ed => ed.Id == detailDto.Id);
                if (existingDetail != null)
                {
                    _mapper.Map(detailDto, existingDetail);
                    existingDetail.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    var newDetail = _mapper.Map<EntryDetail>(detailDto);
                    newDetail.EntryHeaderId = id;
                    newDetail.CreatedAt = DateTime.UtcNow;
                    entryToUpdate.EntryDetails.Add(newDetail);
                }
            }

            var updated = await _entryHeaderRepository.UpdateAsync(id, entryToUpdate);
            if (!updated) return StatusCode(500, "Error al actualizar el voucher.");

            var fullEntry = await _entryHeaderRepository
                .GetQueryable()
                .Include(eh => eh.EntryDetails)
                    .ThenInclude(ed => ed.Account)
                .FirstOrDefaultAsync(eh => eh.Id == id);

            var entryDto = _mapper.Map<EntryHeaderToListDTO>(fullEntry);
            return Ok(entryDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _entryHeaderRepository.GetByIdAsync(id);
            if (entry == null) return NotFound();

            await _entryDetailRepository.DeleteAsync(id);
            await _entryHeaderRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
