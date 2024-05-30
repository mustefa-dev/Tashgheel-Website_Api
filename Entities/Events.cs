using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Tashgheel_Api.Entities
{
    public class Events : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public DateTime? EventDate { get; set; }
        public long? EventTime { get; set; }
        public int? CurrentParticipants { get; set; }=0;
        public int? ParticipantsLimit { get; set; }
        public EventType? EventType { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? EventCost { get; set; }
        
        
    }
}

public enum EventType
{
    Immanence,
    Electronic,
    
}