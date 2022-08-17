using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Core.Services.Event
{
    public class EventResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Venue { get; set; }
    }
}
