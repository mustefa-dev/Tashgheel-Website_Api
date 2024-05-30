namespace Tashgheel_Api.DATA.DTOs
{

    public class NewsDto : BaseDto<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<string> Images {get; set;}

    }
}
