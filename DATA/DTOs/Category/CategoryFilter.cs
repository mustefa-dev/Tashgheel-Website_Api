using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class CategoryFilter : BaseFilter 
    {
        public string? Name { get; set; }
        public CategoryType? Type { get; set; }
    }
}
