using Microsoft.AspNetCore.Mvc;
using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Api.Services;
using Microsoft.AspNetCore.RateLimiting;

namespace Festivise.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("festiviseEventFixed")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventRequestDTO>> GetEventAsync(Guid id)
        {
            var eventResponseDTO = await _eventService.GetEventAsync(id);

            if (eventResponseDTO == null)
            {
                return NotFound();
            }

            return Ok(eventResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EventRequestDTO>> CreateEventAsync(EventRequestDTO eventRequestDTO)
        {
            var eventResponseDTO = await _eventService.CreateEventAsync(eventRequestDTO);

            return CreatedAtAction(nameof(GetEventAsync), new { id = eventResponseDTO.Id }, eventResponseDTO);
        }
    }
}