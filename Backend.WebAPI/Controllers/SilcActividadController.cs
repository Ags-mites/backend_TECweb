using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.SilcActividad;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SilcActividadController : ControllerBase
    {
        private readonly ISilcActividadRepository _silcActividadRepository;
        private readonly IMapper _mapper;

        public SilcActividadController(ISilcActividadRepository silcActividadRepository, IMapper mapper)
        {
            _silcActividadRepository = silcActividadRepository;
            _mapper=mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.SilcActividadToCreateDTO silcActividadToCreateDTO)
        {
            var clientsFacToCreate = _mapper.Map<SilcActividad>(silcActividadToCreateDTO);
            var clientsFacCreated = await _silcActividadRepository.AddAsync(clientsFacToCreate);
            var clientsFacCreateDTO = _mapper.Map<Dtos.SilcActividadToListDTO>(clientsFacCreated);
            return Ok(clientsFacCreateDTO);
        }

    }
}