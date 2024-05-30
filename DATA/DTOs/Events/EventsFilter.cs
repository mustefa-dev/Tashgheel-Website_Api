namespace Tashgheel_Api.DATA.DTOs
{

    public class EventsFilter : BaseFilter 
    {
        public string? Name { get; set; }
       //TODO public DateTime? EventDate { get; set; }
        //public string? Location { get; set; }
        public string? Address { get; set; }
        //TODO public DateTime? EventTime { get; set; }
        public EventType? EventType { get; set; }
    }
}
