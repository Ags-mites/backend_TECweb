using System.Data;
using AutoMapper;
using Backend.DTOs.JabdActividad;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.JabdActividad;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JabdActividadController : ControllerBase
    {
        private readonly IJabdActividadRepository _JabdActividadRepository;
        private readonly IMapper _mapper;

        public JabdActividadController(IJabdActividadRepository JabdActividadRepository, IMapper mapper)
        {
            _JabdActividadRepository = JabdActividadRepository;
            _mapper=mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.JabdActividadToCreateDTO JabdActividadToCreateDTO)
        {
            var JabdActividadToCreate = _mapper.Map<JabdActividad>(JabdActividadToCreateDTO);
            var JabdActividadCreated = await _JabdActividadRepository.AddAsync(JabdActividadToCreate);
            var JabdActividadCreateDTO = _mapper.Map<Dtos.JabdActividadToListDTO>(JabdActividadCreated);
            return Ok(JabdActividadCreateDTO);
        }
    }
}