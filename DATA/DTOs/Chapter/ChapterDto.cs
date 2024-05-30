using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class ChapterDto : BaseDto<Guid>
    {
        public string? Title { get; set; }
        public string? Descreption { get; set; }
        public Status Status { get; set; }
        public Guid? CourseId { get; set; }
        public int order { get; set; }
        public List<Video>? Videos { get; set; }
        

    }
}
