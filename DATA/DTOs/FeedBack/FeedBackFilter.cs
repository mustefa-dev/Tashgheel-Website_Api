namespace Tashgheel_Api.DATA.DTOs
{

    public class FeedBackFilter : BaseFilter 
    {
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public FeddBackType? Type { get; set; }
    }
}
