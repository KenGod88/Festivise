using Festivise.Events.Api.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Storage
{
    public interface IPosterRepository
    {
        Task<string> GenerateEventPosterAsync(EventResponseDTO eventDTO);
        
    }
}
