using Microsoft.AspNetCore.Mvc;
using Backend.Persistence.Interfaces;
using Dtos = Backend.DTOs.PayrollHeader;
using Backend.DTOs.PayrollHeader;
using Backend.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/payrolls")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollHeaderRepository _payrollHeaderRepository;
        private readonly IPayrollDetailRepository _payrollDetailRepository;
        private readonly IMapper _mapper;

        public PayrollController(IPayrollHeaderRepository payrollHeaderRepository, IPayrollDetailRepository payrollDetailRepository, IMapper mapper)
        {
            _payrollHeaderRepository = payrollHeaderRepository;
            _payrollDetailRepository = payrollDetailRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetPayrollHeader()
        {
            var payrolls = await _payrollHeaderRepository
                .GetQueryable()
                .Include(ph => ph.Worker)
                .Include(ph => ph.PayrollDetails)
                    .ThenInclude(pd => pd.Reason)
                .ToListAsync();

            var payrollsDto = _mapper.Map<List<PayrollHeaderToListDTO>>(payrolls);
            return Ok(payrollsDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var payroll = await _payrollHeaderRepository
                .GetQueryable()
                .Include(ph => ph.Worker)
                .Include(ph => ph.PayrollDetails)
                    .ThenInclude(pd => pd.Reason)
                .FirstOrDefaultAsync(ph => ph.Id == id);

            if (payroll == null) return NotFound();

            var PayrollHeaderDto = _mapper.Map<Dtos.PayrollHeaderToListDTO>(payroll);
            return Ok(PayrollHeaderDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PayrollHeaderToCreateDTO payrollHeaderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payrollHeader = _mapper.Map<PayrollHeader>(payrollHeaderDto);

            payrollHeader.PayrollDetails = [];
            payrollHeader.CreatedAt = DateTime.UtcNow;
            payrollHeader.UpdatedAt = DateTime.UtcNow;

            var createdPayroll = await _payrollHeaderRepository.AddAsync(payrollHeader);

            if (payrollHeaderDto.PayrollDetails?.Any() == true)
            {
                var payrollDetails = _mapper.Map<List<PayrollDetail>>(payrollHeaderDto.PayrollDetails);
                foreach (var detail in payrollDetails)
                {
                    detail.PayrollHeaderId = createdPayroll.Id;
                    detail.CreatedAt = DateTime.UtcNow;
                    detail.UpdatedAt = DateTime.UtcNow;
                }
                await _payrollDetailRepository.AddAll(payrollDetails);
            }

            return await GetById(createdPayroll.Id);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PayrollHeaderToEditDTO payrollHeaderDto)
        {
            if (id != payrollHeaderDto.Id)
                return BadRequest("El ID proporcionado no coincide con el objeto.");

            var payrollToUpdate = await _payrollHeaderRepository.GetQueryable()
                .Include(ph => ph.PayrollDetails)
                .FirstOrDefaultAsync(ph => ph.Id == id);

            if (payrollToUpdate == null)
                return NotFound("La nómina no fue encontrada.");

            _mapper.Map(payrollHeaderDto, payrollToUpdate);
            payrollToUpdate.UpdatedAt = DateTime.UtcNow;

            var newDetailsIds = payrollHeaderDto.PayrollDetails?.Select(d => d.Id).ToList() ?? new List<int>();

            var detailsToRemove = payrollToUpdate.PayrollDetails
                .Where(pd => !newDetailsIds.Contains(pd.Id))
                .ToList();

            foreach (var detail in detailsToRemove)
            {
                payrollToUpdate.PayrollDetails.Remove(detail);
            }

            foreach (var detailDto in payrollHeaderDto.PayrollDetails)
            {
                var existingDetail = payrollToUpdate.PayrollDetails.FirstOrDefault(pd => pd.Id == detailDto.Id);
                if (existingDetail != null)
                {
                    _mapper.Map(detailDto, existingDetail);
                    existingDetail.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    var newDetail = _mapper.Map<PayrollDetail>(detailDto);
                    newDetail.PayrollHeaderId = id;
                    newDetail.CreatedAt = DateTime.UtcNow;
                    payrollToUpdate.PayrollDetails.Add(newDetail);
                }
            }

            var updated = await _payrollHeaderRepository.UpdateAsync(id, payrollToUpdate);
            if (!updated) return StatusCode(500, "Error al actualizar la nómina.");

            return await GetById(payrollToUpdate.Id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payroall = await _payrollHeaderRepository.GetByIdAsync(id);

            if (payroall is null)
            {
                return NotFound("Registro no encontrado");
            }

            await _payrollDetailRepository.DeleteAsync(id);
            await _payrollHeaderRepository.DeleteAsync(id);

            return Ok("Registro eliminado");
        }

    }
}