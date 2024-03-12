using System.Data;
using AutoMapper;
using Backend.DTOs.AuditAM;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.AuditAM;

namespace Backend.WebAPI.Controllers
{
    [Route("audit/v1/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditAMRepository _auditAMRepository;
        private readonly IMapper _mapper;

        public AuditController(IAuditAMRepository auditAMRepository, IMapper mapper)        {
            _auditAMRepository = auditAMRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.AuditAMToCreateDTO auditAMToCreateDTO)
        {
            var auditDTOCreate = _mapper.Map<AuditAM>(auditAMToCreateDTO);
            var auditAMCreated = await _auditAMRepository.AddAsync(auditDTOCreate);
            var auditAMCreadteDTO = _mapper.Map<Dtos.AuditAMToCreateDTO>(auditAMCreated);
            return Ok (auditAMCreadteDTO);
        }
    }
}