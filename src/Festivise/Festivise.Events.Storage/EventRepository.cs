using Festivise.Events.Storage.Context;
using Festivise.Events.Storage.Contracts;

namespace Festivise.Events.Storage
{
    public class EventRepository : IEventRepository
    {
        private readonly FestiviseContext _dbcontext;

        public EventRepository(FestiviseContext context)
        {
            _dbcontext = context;
        }

        public async Task<EventModel> CreateEventAsync(EventModel eventToAdd)
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

        public async Task<EventModel> GetEventAsync(Guid id)
        {

            var eventModel = await _dbcontext.Events.FindAsync(id);
            var acts = _dbcontext.Acts.Where(a => a.EventId == id).ToList();
            eventModel.Acts = acts;
           
            return eventModel;
            
        }
    }
}