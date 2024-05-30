using Tashgheel_Api.DATA.DTOs.User;
using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class EventRegistrationDto : BaseDto<Guid>
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public EventRegistrationStatus Status { get; set; }
        
    }
}
