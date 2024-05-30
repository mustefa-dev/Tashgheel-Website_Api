namespace Tashgheel_Api.DATA.DTOs
{

    public class EventsUpdate
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public DateTime? Time { get; set; }
        public EventType? Type { get; set; }
    }
}
