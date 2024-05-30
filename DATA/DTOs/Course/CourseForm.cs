using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class CourseForm 
    {
        //public Guid? UserId { get; set; }
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Price { get; set; }
        public float? Discount { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Level { get; set; }
        public string? Language { get; set; }
        public string? TimeDuration { get; set; }
        public int? NumOfVideos { get; set; }

    }
}
