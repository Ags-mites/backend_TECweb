using System.Data;
using AutoMapper;
using Backend.DTOs.Movements;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Movements;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovementController: ControllerBase
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public MovementController(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllMovement()
        {
            var movement =  await _movementRepository.GetAllAsync();
            var movementsDTO = _mapper.Map<List<Dtos.MovementToListDTO>>(movement);
            return Ok(movementsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var movement =  await _movementRepository.GetByIdAsync(id);
            var movementDTO = _mapper.Map<Dtos.MovementToListDTO>(movement);
            return Ok(movementDTO);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.MovementToCreateDTO movementToCreateDTO)
        {
            var movementToCreate = _mapper.Map<Movement>(movementToCreateDTO);
            movementToCreate.CreatedAt = DateTime.Now;
            var movementCreated = await _movementRepository.AddAsync(movementToCreate);
            var movementCreateDTO = _mapper.Map<Dtos.MovementToListDTO>(movementCreated);
            return Ok(movementCreateDTO);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.MovementToEditDTO movementToEdit)
        {
            if(id != movementToEdit.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var movementToUpdate = await _movementRepository.GetByIdAsync(id);
            if(movementToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(movementToEdit,movementToUpdate);
            movementToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _movementRepository.UpdateAsync( id ,movementToUpdate);
            if(!updated){
                return NoContent();
            }
            var movement = await _movementRepository.GetByIdAsync(id);
            var movementDTO = _mapper.Map<Dtos.MovementToListDTO>(movement);
            return Ok(movementDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var movementeToDelete = await _movementRepository.GetByIdAsync(id);

            if(movementeToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _movementRepository.DeleteAsync(movementeToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}
