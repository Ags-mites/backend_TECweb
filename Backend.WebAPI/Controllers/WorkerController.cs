using System.Data;
using AutoMapper;
using Backend.DTOs.Worker;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Worker;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkersRepository _workersRepository;
        private readonly IMapper _mapper;

        public WorkerController(IWorkersRepository workersRepository, IMapper mapper)
        {
            _workersRepository = workersRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllWorkers()
        {
            var workers =  await _workersRepository.GetAllAsync();
            var WorkerDto = _mapper.Map<List<Dtos.WorkerToListDTO>>(workers);
            return Ok(WorkerDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var worker =  await _workersRepository.GetByIdAsync(id);
            var workerDto = _mapper.Map<Dtos.WorkerToListDTO>(worker);
            return Ok(workerDto);
        }

        [HttpPost]
        public async Task <IActionResult> Post(Dtos.WorkerToCreateDTO workerToCreateDTO)
        {
            var workerToCreate = _mapper.Map<Worker>(workerToCreateDTO);
            workerToCreate.CreatedAt = DateTime.Now;
            var workerCreated = await _workersRepository.AddAsync(workerToCreate);
            var workerCreateDTO = _mapper.Map<Dtos.WorkerToListDTO>(workerCreated);
            return Ok(workerCreateDTO);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, Dtos.WorkerToEditDTO workerToEdit)
        {
            if(id != workerToEdit.Id)
            {
                return  BadRequest("Error en los datos de entrada");
            }
            var workerToUpdate = await _workersRepository.GetByIdAsync(id);
            if(workerToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }
            
            _mapper.Map(workerToEdit,workerToUpdate);
            workerToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _workersRepository.UpdateAsync( id ,workerToUpdate);
            if(!updated){
                return NoContent();
            }
            var worker = await _workersRepository.GetByIdAsync(id);
            var workerDTO = _mapper.Map<Dtos.WorkerToListDTO>(worker);
            return Ok(workerDTO);
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var workerToDelete = await _workersRepository.GetByIdAsync(id);

            if(workerToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _workersRepository.DeleteAsync(workerToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }

    }
}