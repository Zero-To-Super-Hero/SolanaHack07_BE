using off_chain.Models;

namespace off_chain.Services.EventService
{
    public interface IEventService
    {
        Task<Event> AddEvent(Event @event);
    }
}
