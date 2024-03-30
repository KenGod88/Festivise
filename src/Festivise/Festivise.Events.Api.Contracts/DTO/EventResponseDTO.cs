using Festivise.Events.Api.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Api.Contracts.DTO
{
    public class EventResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public VenueEnum Venue { get; set; }
        public List<ActRequestDTO> Acts { get; set; }
    }
}
