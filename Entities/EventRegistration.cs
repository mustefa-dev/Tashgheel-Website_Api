using System.ComponentModel.DataAnnotations.Schema;

namespace Tashgheel_Api.Entities
{
    public class EventRegistration  : BaseEntity<Guid>
    {
        
        public string UserName { get; set; }
        public Guid EventId { get; set; }
        public EventRegistrationStatus Status { get; set; }
        public string Email { get; set; }
       
        public DateTime RegistrationDate { get; set; }
        public Events Event { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser AppUser { get; set; }
    }
    public enum EventRegistrationStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }


}
