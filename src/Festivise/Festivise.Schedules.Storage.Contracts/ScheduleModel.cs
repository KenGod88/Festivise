using Festivise.Events.Storage.Contracts;

namespace Festivise.Schedules.Storage.Contracts
{
    public class ScheduleModel
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string EventName { get; set; }
        public Guid EventId { get; set; }
        public List<ActModel> Acts { get; set; }
        public string EventVenue { get; set; }
        public string UserId { get; set; }

    }
}
