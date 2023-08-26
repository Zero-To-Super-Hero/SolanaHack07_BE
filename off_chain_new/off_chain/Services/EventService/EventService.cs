using off_chain.DBContext;
using off_chain.Models;

namespace off_chain.Services.EventService
{
    public class EventService : IEventService
    {

        private readonly MyDbContext _myDbContext;
        public EventService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<Event> AddEvent(Event @event)
        {
            _myDbContext.Events.Add(@event);
            _myDbContext.SaveChanges();
            return @event;
        }
    }
}
