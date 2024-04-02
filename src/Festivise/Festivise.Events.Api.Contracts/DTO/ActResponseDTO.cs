using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Api.Contracts.DTO
{
    public class ActResponseDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
