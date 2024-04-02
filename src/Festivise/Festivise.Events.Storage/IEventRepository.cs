using Festivise.Events.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Storage
{
    public interface IEventRepository
    {
        Task<Event> GetEventAsync(Guid id);
        Task<Event> CreateEventAsync(Event eventToAdd);
    }
}
