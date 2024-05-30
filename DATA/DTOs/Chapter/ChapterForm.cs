using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class ChapterForm 
    {
        public string? Title { get; set; }
        public string? Descreption { get; set; }
        public Status Status { get; set; }
        public int order { get; set; }
    }
}
