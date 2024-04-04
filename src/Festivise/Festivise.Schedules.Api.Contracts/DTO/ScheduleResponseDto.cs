using Festivise.Events.Storage.Contracts;

namespace Festivise.Schedules.Api.Contracts.DTO
{
    public class ScheduleResponseDto
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public Guid EventId { get; set; }
        public List<ActModel> Acts { get; set; }
        public string EventVenue { get; set; }
        public string UserId { get; set; }
    }
}