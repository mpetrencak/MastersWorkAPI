namespace MinimalApi.Core.DomainEntities
{
    public class Event : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Venue { get; set; }
    }
}
