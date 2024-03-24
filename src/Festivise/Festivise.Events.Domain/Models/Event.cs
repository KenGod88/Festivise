using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Domain.Models
{
    internal class Event
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
