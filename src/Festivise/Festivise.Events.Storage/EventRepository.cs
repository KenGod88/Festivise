using Festivise.Events.Domain.Models;
using Festivise.Events.Storage.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Storage
{
    public class EventRepository : IEventRepository
    {
        private readonly FestiviseContext _dbcontext;

        public EventRepository(FestiviseContext context)
        {
            _dbcontext = context;
        }

        public async Task<Event> CreateEventAsync(Event eventToAdd)
        {
            try
            {
                await _dbcontext.Events.AddAsync(eventToAdd);
                await _dbcontext.SaveChangesAsync();
                return eventToAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating event", ex);
            }
            
        }

        public async Task<Event> GetEventAsync(Guid id)
        {

            var eventModel = await _dbcontext.Events.FindAsync(id);
            var acts = _dbcontext.Acts.Where(a => a.EventId == id).ToList();
            eventModel.Acts = acts;
           
            return eventModel;
            
        }
    }
}