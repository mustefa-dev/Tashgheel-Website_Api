using System.ComponentModel.DataAnnotations.Schema;

namespace Tashgheel_Api.Entities
{
    public class Chapter : BaseEntity<Guid>
    {
        public string? Title { get; set; }
        public string? Descreption { get; set; }
        public List<Video>? Videos { get; set; }
        public Status Status { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(CourseId))]
        
        public Guid? CourseId { get; set; }
        
        public int? order { get; set; }
    
    }

    public enum Status
    {
        Completed = 0,
        Playing= 1,
        NotCompleted= 2,
    }
}
