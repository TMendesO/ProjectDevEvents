using DevEvents.API.Entities;

namespace ProjectDevEvents.API.Persistence
{
    public class DevEventsDBContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public DevEventsDBContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }

}
