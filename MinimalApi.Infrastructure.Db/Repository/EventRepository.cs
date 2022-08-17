using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MinimalApi.Core.DomainEntities;
using MinimalApi.Core.Infrastructure;
using MinimalApi.Infrastructure.Db.DatabaseObjects;

namespace MinimalApi.Infrastructure.Db.Repository
{
    internal class EventRepository : IEventRepository
    {
        private readonly ILogger<EventRepository> _logger;
        private readonly MinimalApiDbContext _context;
        private readonly IMapper _mapper;

        public EventRepository(ILogger<EventRepository> logger, MinimalApiDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Event newEvent)
        {
            _logger.LogInformation($"Task AddAsync({newEvent.Name})");

            var eventDo = _mapper.Map<EventDo>(newEvent);
            await _context.AddAsync(eventDo);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Event>> GetAllAsync()
        {
            _logger.LogInformation($"Task<IReadOnlyCollection<Event>> GetAllAsync()");

            var eventsDo = await _context.Events.ToListAsync();
            return _mapper.Map<IReadOnlyCollection<Event>>(eventsDo);
        }
    }
}
