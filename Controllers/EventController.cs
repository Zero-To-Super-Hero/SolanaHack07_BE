using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using off_chain.Models;
using off_chain.Services.EventService;

namespace off_chain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _event;
        public EventController(IEventService @event) 
        {
            _event = @event;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("sdsdsdsd");
        }
        [HttpPost]
        public async Task <IActionResult> AddEvent(Event @event)
        {
            await _event.AddEvent(@event);
            return Ok();
        }
    }
}
