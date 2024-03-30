using Microsoft.AspNetCore.Mvc;
using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Api.Services;

namespace Festivise.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<EventRequestDTO>> GetEvent(Guid id)
        {
            var eventResponseDTO = await _eventService.GetEvent(id);

            if (eventResponseDTO == null)
            {
                return NotFound();
            }

            return Ok(eventResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EventRequestDTO>> CreateEvent(EventRequestDTO eventRequestDTO)
        {
            var eventResponseDTO = await _eventService.CreateEvent(eventRequestDTO);

            return CreatedAtAction(nameof(GetEvent), new { id = eventResponseDTO.Id }, eventResponseDTO);
        }
    }
}