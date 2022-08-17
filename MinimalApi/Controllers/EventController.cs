using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Core.Services.Event;

namespace MinimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Policy = Policies.CanHaveModerator)]
        public async Task Create(CreateEventRequest createEventRequest)
        {
            _logger.LogInformation("POST request to 'api/event/create' ");
            await _eventService.AddEventAsync(createEventRequest);
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        [AllowAnonymous]
        public async Task<IReadOnlyCollection<EventResponse>> GetAll()
        {
            _logger.LogInformation("GET request to 'api/event/GetAll' ");
            return await _eventService.GetAllAsync();
        }
    }
}
