namespace Tashgheel_Api.DATA.DTOs
{

    public class EventsDto: BaseDto<Guid>
    {
        public string? Name { get; set; }
        public DateTime? EventDate { get; set; }
        public long? EventTime { get; set; }
        public EventType? EventType { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? EventCost { get; set; }
        public Guid UserId { get; set; }
        public int? ParticipantsLimit { get; set; }
        public int? CurrentParticipants { get; set; }

    }
}
