using MinimalApi.Core.Infrastructure;

namespace MinimalApi.Core.Services.Event
{
    internal class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEventAsync(CreateEventRequest createEventRequest)
        {
            var newEvent = new DomainEntities.Event
            {
                Id = new Guid(),
                Name = createEventRequest.Name,
                Venue = createEventRequest.Venue,
                StartTime = createEventRequest.StartTime,
                EndTime = createEventRequest.EndTime,

            };

            await _repository.AddAsync(newEvent);
        }

        public async Task<IReadOnlyCollection<EventResponse>> GetAllAsync()
        {
            var events = await _repository.GetAllAsync();

            var eventsResponse = events.Select(ToEventResponse).ToList();

            return eventsResponse;
        }

        private static EventResponse ToEventResponse(DomainEntities.Event eventToResponse)
        {
            var response = new EventResponse
            {
                Id = eventToResponse.Id,
                Name = eventToResponse.Name,
                Venue = eventToResponse.Venue,
                StartTime = eventToResponse.StartTime,
                EndTime = eventToResponse.EndTime,
            };
            return response;
        }
    }
}
