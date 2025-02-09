using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Backend.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Cities;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _citiesFacRepository;
        private readonly IMapper _mapper;
        private readonly ICitiesRepository _citiesRepository;

        public CitiesController(ICitiesRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository; // Inyección del repositorio de ciudades
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCities() // Cambiado el nombre del método
        {
            var cities = await _citiesRepository.GetAllAsync(); // Obtiene una lista de ciudades
            var citiesDto = _mapper.Map<List<Dtos.CitiesToListDTO>>(cities); // Mapea ciudades a DTOs
            return Ok(citiesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var city = await _citiesRepository.GetByIdAsync(id); // Cambiado a ciudad
            if (city == null)
            {
                return NotFound("Ciudad no encontrada");
            }
            var cityDto = _mapper.Map<Dtos.CitiesToListDTO>(city); // Mapea ciudad a DTO
            return Ok(cityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.CitiesToCreateDTO cityToCreateDTO)
        {
            var cityToCreate = _mapper.Map<Cities>(cityToCreateDTO); // Mapea DTO a entidad
            var cityCreated = await _citiesRepository.AddAsync(cityToCreate); // Agrega la ciudad
            var cityCreateDTO = _mapper.Map<Dtos.CitiesToListDTO>(cityCreated); // Mapea la ciudad creada a DTO
            return Ok(cityCreateDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.CitiesToEditDTO cityToEditDTO)
        {
            if (id != cityToEditDTO.Id)
            {
                return BadRequest("Error en los datos de entrada");
            }
            var cityToUpdate = await _citiesRepository.GetByIdAsync(id);
            if (cityToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(cityToEditDTO, cityToUpdate); // Mapea el DTO a la entidad existente
            var updated = await _citiesRepository.UpdateAsync(id, cityToUpdate);
            if (!updated)
            {
                return NoContent();
            }
            var city = await _citiesRepository.GetByIdAsync(id);
            var cityDto = _mapper.Map<Dtos.CitiesToListDTO>(city); // Mapea la ciudad actualizada a DTO
            return Ok(cityDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cityToDelete = await _citiesRepository.GetByIdAsync(id);

            if (cityToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _citiesRepository.DeleteAsync(cityToDelete);

            if (!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }
    }
}