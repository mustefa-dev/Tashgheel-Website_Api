namespace Tashgheel_Api.Entities
{
    public class UserCourse : BaseEntity<Guid>
    {
        public AppUser? User { get; set; }
        public Guid? UserId { get; set; }
        public Course? Course { get; set; }
        public Guid? CourseId { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsFavorite { get; set; }
        public bool? IsPurchased { get; set; }=false;
        public bool? IsWishlist { get; set; }
       // public float? Progress { get; set; }
        //public float? Rating { get; set; }
       // public string? Review { get; set; }
    }
}
