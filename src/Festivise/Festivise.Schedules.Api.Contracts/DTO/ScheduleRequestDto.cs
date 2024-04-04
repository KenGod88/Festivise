using System.ComponentModel.DataAnnotations;

namespace Festivise.Schedules.Api.Contracts.DTO
{
    public class ScheduleRequestDto
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        public string? UserId { get; set; }
    }
}
