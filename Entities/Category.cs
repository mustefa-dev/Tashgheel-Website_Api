namespace Tashgheel_Api.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string?  Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Service> Services { get; set; }
        public CategoryType Type { get; set; }
    }
    
    public enum CategoryType
    {
        Course=0,
        Service=1,
    }
    
}
