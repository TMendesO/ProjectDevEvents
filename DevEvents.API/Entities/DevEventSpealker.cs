namespace DevEvents.API.Entities
{
    public class DevEventSpealker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TalkTitle {get; set; }
        public string TalkDescription { get; set;}
        public string LinkedInProfile {  get; set; }
    }
}