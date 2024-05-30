using System.ComponentModel.DataAnnotations.Schema;

namespace Tashgheel_Api.Entities
{
    public class Course : BaseEntity<Guid>
    {
        public AppUser? Creator { get; set; }
        public Guid? CreatorId { get; set; }
        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Price { get; set; }
        public float? Discount { get; set; }
        public Category? Category { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Guid? CategoryId { get; set; }
        public List <Chapter>? Chapters { get; set; }
        public List<Review>? Reviews { get; set; }
        //Tags
        public string? Level { get; set; }
        public string? Language { get; set; }
        public string? TimeDuration { get; set; }
        public int? NumOfVideos { get; set; }
        public List<UserCourse>? UserCourses { get; set; }
        
        
    }
}
