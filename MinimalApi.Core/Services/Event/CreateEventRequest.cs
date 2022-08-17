namespace MinimalApi.Core.Services.Event
{
    public class CreateEventRequest
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Venue { get; set; }
    }
}
