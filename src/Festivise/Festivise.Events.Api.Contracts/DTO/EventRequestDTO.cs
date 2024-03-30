using Festivise.Events.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Api.Contracts.DTO
{
    internal class EventRequestDTO
    {
        public Guid Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public DateTime StartTime { get; set; }

        
        public DateTime EndTime { get; set; }

        
        public string Venue { get; set; }

        
        public List<Act> Acts { get; set; }

        
       

    }
}
