using System.Data;
using AutoMapper;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.FacturacionCliente;

namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FFacturacionClienteController : ControllerBase
    {
        private readonly IFacturacionClienteRepository _clientsFacRepository;
        private readonly IMapper _mapper;

        public FFacturacionClienteController(IFacturacionClienteRepository clientsFacRepository, IMapper mapper)
        {
            _clientsFacRepository = clientsFacRepository;
            _mapper=mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllclientsFacs()
        {
            var clients =  await _clientsFacRepository.GetAllAsync();
            var clientsDto = _mapper.Map<List<Dtos.FacturacionClienteToListDTO>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var clients =  await _clientsFacRepository.GetByIdAsync(id);
            var clientsDto = _mapper.Map<Dtos.FacturacionClienteToListDTO>(clients);
            return Ok(clientsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(List<Dtos.FacturacionClienteToCreateDTO> facturacionClienteToCreateDTOs)
        {
            foreach (var facturacionClienteToCreateDTO in facturacionClienteToCreateDTOs)
            {
                var faCliente = _mapper.Map<FacturacionCliente>(facturacionClienteToCreateDTO);
                var clientsFacCreated = await _clientsFacRepository.AddAsync(faCliente);
                var clientsFacCreateDTO = _mapper.Map<Dtos.FacturacionClienteToListDTO>(clientsFacCreated);
            }
            
            // Aquí puedes agregar cualquier lógica adicional
            
            return Ok(); // Retorna un Ok sin contenido si la inserción es exitosa
        }
        
       [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, List<Dtos.FacturacionClienteToEditDTO> clientsFacToEditDTOs)
        {
            if (clientsFacToEditDTOs == null || !clientsFacToEditDTOs.Any())
            {
                return BadRequest("No se proporcionaron datos para actualizar.");
            }

            var result = new List<Dtos.FacturacionClienteToListDTO>();

            foreach (var clientsFacToEditDTO in clientsFacToEditDTOs)
            {
                if (id != clientsFacToEditDTO.Id)
                {
                    return BadRequest("Error en los datos de entrada: el ID no coincide.");
                }

                var clientsFacToUpdate = await _clientsFacRepository.GetByIdAsync(id);
                if (clientsFacToUpdate == null)
                {
                    return BadRequest("ID no encontrado.");
                }

                _mapper.Map(clientsFacToEditDTO, clientsFacToUpdate);
                var updated = await _clientsFacRepository.UpdateAsync(id, clientsFacToUpdate);
                if (!updated)
                {
                    return NoContent();
                }

                var clientsDto = _mapper.Map<Dtos.FacturacionClienteToListDTO>(clientsFacToUpdate);
                result.Add(clientsDto);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var clientsFacToDelete = await _clientsFacRepository.GetByIdAsync(id);

            if(clientsFacToDelete is null)
            {
                return NotFound("Registro no encontrado");
            }

            var deleted = await _clientsFacRepository.DeleteAsync(clientsFacToDelete);
            
            if(!deleted)
            {
                return Ok("Error al eliminar el registro");
            }

            return Ok("Registro eliminado");
        }



    }
}