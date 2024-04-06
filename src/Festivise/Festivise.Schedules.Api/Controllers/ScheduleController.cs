using Festivise.Schedules.Api.Contracts.DTO;
using Festivise.Schedules.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Festivise.Schedules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleResponseDto>> CreateSchedule([FromBody] ScheduleRequestDto request)
        {
            
            var schedule = await _scheduleService.CreateScheduleAsync(request);
            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleResponseDto>> GetSchedule(string id)
        {
            var schedule = await _scheduleService.GetScheduleAsync(id);
            
            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }
    }
}
