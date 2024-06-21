using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Data;
using TestWebApi.Dtos.StateAndCapital;
using TestWebApi.Interface;
using TestWebApi.Mappers;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{

    [Route("api/state")]
    [ApiController]
    public class StateCapitalController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IStateCapitalRepository _stateRepo;
        public StateCapitalController(ApplicationDbContext context, IStateCapitalRepository stateRepo)
        {
            _stateRepo = stateRepo;
            _context = context;

        }

        [HttpGet("GetStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var states = await _context.StateAndCapitals.Select(x => x.StateName).ToListAsync();
            return Ok(states);
        }


        [HttpGet("GetCapitals")]
        public async Task<IActionResult> GetAllCapitals()
        {
            var states = await _context.StateAndCapitals.Select(x => x.CapitalName).ToListAsync();
            return Ok(states);
        }
        [HttpGet("GetStatesAndCapitals")]
        public async Task<IActionResult> GetStateandCapital()
        {
            var states = await _context.StateAndCapitals.ToListAsync();
            return Ok(states);
        }



        [HttpGet("state/{stateName}")]

        public async Task<IActionResult> GetByState([FromRoute] string stateName)
        {
            var state = await _context.StateAndCapitals.FirstOrDefaultAsync(x => x.StateName== stateName);

            if (state == null)
            {
                return NotFound();

            }

            return Ok(state.ToCapitalDto());
        }

        [HttpGet("capital/{capitalName}")]

        public async Task<IActionResult> GetByCapital([FromRoute] string capitalName)
        {
            var state = await _context.StateAndCapitals.FirstOrDefaultAsync(x => x.CapitalName == capitalName);

            if (state == null)
            {
                return NotFound();

            }

            return Ok(state.ToStateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StateAndCapitalDto stateDto)
        {
           
            var stateModel = await _context.StateAndCapitals.FirstOrDefaultAsync(x => x.StateName == stateDto.StateName || x.CapitalName == stateDto.CapitalName);
            if (stateModel!= null)
            {
                return BadRequest("Duplicate Entry");
            }
            else
            {
                await _context.StateAndCapitals.AddAsync(stateDto.ToStateCapitalFromAddDTO());
                await _context.SaveChangesAsync();
                return Ok(stateDto);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var stateModel = await _stateRepo.DeleteAsync(id);

            if (stateModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
