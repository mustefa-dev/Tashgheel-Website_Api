namespace Tashgheel_Api.DATA.DTOs
{

    public class CourseFilter : BaseFilter 
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
        public float? Discount { get; set; }
        public string? CategoryName { get; set; }
    }
}
