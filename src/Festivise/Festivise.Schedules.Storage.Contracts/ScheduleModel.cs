using Festivise.Events.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Storage.Contracts
{
    public class ScheduleModel
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public Guid EventId { get; set; }
        public List<Act> Acts { get; set; }
        public string EventVenue { get; set; }
        public string UserId { get; set; }

    }
}
