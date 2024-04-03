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
        
        public Guid EventId { get; set; }
        
       
        public string UserId { get; set; }
    }
}
