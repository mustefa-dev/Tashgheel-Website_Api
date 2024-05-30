using System.ComponentModel.DataAnnotations.Schema;

namespace Tashgheel_Api.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Password { get; set; }
        
        public UserRole? Role { get; set; }

        public bool? IsActive { get; set; }

        public List<Appointment>? Appointments { get; set; }
        public List<Course>? Courses{ get; set; }
        public List<UserCourse>? UserCourses { get; set; }
       




    }
    public enum UserRole
    {
       
        Admin = 0,
        User = 1,
        CompanyUser = 2,
        Creator = 3,
    }
    
}