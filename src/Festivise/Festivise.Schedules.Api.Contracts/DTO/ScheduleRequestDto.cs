using Festivise.Events.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Api.Contracts.DTO
{
    public class ScheduleRequestDto
    {
        [Required]
        public Guid? EventId { get; set; }

        [Required]
        public string? UserId { get; set; }
    }
}
