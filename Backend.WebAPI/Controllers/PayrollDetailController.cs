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
    [Route("PayrollDetail/v1/[controller]")]
    [ApiController]
    public class PayrollDetailController : ControllerBase
    {
        private readonly IPayrollDetailRepository _PayrollDetailRepository;
        private readonly IMapper _mapper;

        public PayrollDetailController(IPayrollDetailRepository PayrollDetailRepository, IMapper mapper)        {
            _PayrollDetailRepository = PayrollDetailRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.PayrollDetailToCreateDTO PayrollDetailToCreateDTO)
        {
            var PayrollDetailDTOCreate = _mapper.Map<PayrollDetail>(PayrollDetailToCreateDTO);
            var PayrollDetailCreated = await _PayrollDetailRepository.AddAsync(PayrollDetailDTOCreate);
            var PayrollDetailCreadteDTO = _mapper.Map<Dtos.PayrollDetailToCreateDTO>(PayrollDetailCreated);
            return Ok (PayrollDetailCreadteDTO);
        }
    }
}