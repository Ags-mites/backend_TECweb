
using System.Data;
using AutoMapper;
using Backend.DTOs.Account;
using Backend.DTOs.AccountType;
using Backend.Entities;
using Backend.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos = Backend.DTOs.Account;


namespace Backend.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IEntryHeaderRepository _entryHeaderRepository;
        private readonly IMapper _mapper;

        public AccountDetailsController(IEntryHeaderRepository entryHeaderRepository, IMapper mapper)
        {
            _entryHeaderRepository = entryHeaderRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAccountsWithTypes()
        {
            var accounts = await _entryHeaderRepository
                .GetQueryable()
                .Include(a => a.EntryDetails) 
                .ToListAsync();

            var accountsWithTypesDto = _mapper.Map<List<AccountToListDTO>>(accounts);
            return Ok(accountsWithTypesDto);
        }
    }
}
