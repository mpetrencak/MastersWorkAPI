namespace MinimalApi.Infrastructure.Db.DatabaseObjects
{
    public class EventDo : IEntityDo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Venue { get; set; }
    }
}
