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
    [Route("PayrollHeader/v1/[controller]")]
    [ApiController]
    public class PayrollHeaderController : ControllerBase
    {
        private readonly IPayrollHeaderRepository _PayrollHeaderRepository;
        private readonly IMapper _mapper;

        public PayrollHeaderController(IPayrollHeaderRepository PayrollHeaderRepository, IMapper mapper)        {
            _PayrollHeaderRepository = PayrollHeaderRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.PayrollHeaderToCreateDTO PayrollHeaderToCreateDTO)
        {
            var PayrollHeaderDTOCreate = _mapper.Map<PayrollHeader>(PayrollHeaderToCreateDTO);
            var PayrollHeaderCreated = await _PayrollHeaderRepository.AddAsync(PayrollHeaderDTOCreate);
            var PayrollHeaderCreadteDTO = _mapper.Map<Dtos.PayrollHeaderToCreateDTO>(PayrollHeaderCreated);
            return Ok (PayrollHeaderCreadteDTO);
        }
    }
}