using Festivise.Events.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Api.Contracts.DTO
{
    public class ScheduleRequestDto
    {
        public string EventName { get; set; }
        public Guid EventId { get; set; }
        public List<Act> Acts { get; set; }
        public string EventVenue { get; set; }
        public string UserId { get; set; }
    }
}
