namespace MinimalApi.Core.Services.Event
{
    public interface IEventService
    {
        public Task AddEventAsync(CreateEventRequest createEventRequest);
        public Task<IReadOnlyCollection<EventResponse>> GetAllAsync();
    }
}
