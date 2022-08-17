using MinimalApi.Core.DomainEntities;

namespace MinimalApi.Core.Infrastructure
{
    public interface IEventRepository
    {
        Task AddAsync(Event newEvent);
        Task<IReadOnlyCollection<Event>> GetAllAsync();
    }
}
