namespace Tashgheel_Api.Entities
{
    public class FeedBack : BaseEntity<Guid>
    {
        public string? Fullname{ get; set; }
        
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        
        public FeddBackType? Type { get; set; }
        public string? Message { get; set; }
        
    }
}
public enum FeddBackType
{
    Technical,
    SearchForEmployee,
    SearchForJob,
    Other
} 