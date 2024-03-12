using System.Data;
using AutoMapper;
using Backend.DTOs.MR_ACTIVIDAD;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.MR_ACTIVIDAD;

namespace Backend.WebAPI.Controllers
{
    [Route("MR_ACTIVIDAD/v1/[controller]")]
    [ApiController]
    public class MR_ACTIVIDADController : ControllerBase
    {
        private readonly IMR_ACTIVIDADRepository _MR_ACTIVIDADRepository;
        private readonly IMapper _mapper;

        public MR_ACTIVIDADController(IMR_ACTIVIDADRepository MR_ACTIVIDADRepository, IMapper mapper)        {
            _MR_ACTIVIDADRepository = MR_ACTIVIDADRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.MR_ACTIVIDADToCreateDTO MR_ACTIVIDADToCreateDTO)
        {
            var MR_ACTIVIDADDTOCreate = _mapper.Map<MR_ACTIVIDAD>(MR_ACTIVIDADToCreateDTO);
            var MR_ACTIVIDADCreated = await _MR_ACTIVIDADRepository.AddAsync(MR_ACTIVIDADDTOCreate);
            var MR_ACTIVIDADCreadteDTO = _mapper.Map<Dtos.MR_ACTIVIDADToCreateDTO>(MR_ACTIVIDADCreated);
            return Ok (MR_ACTIVIDADCreadteDTO);
        }
    }
}