namespace Tashgheel_Api.DATA.DTOs
{

    public class VideoDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? Thumbnail { get; set; }
        public int? Order { get; set; }
        public Guid? ChapterId { get; set; }
    }
}
