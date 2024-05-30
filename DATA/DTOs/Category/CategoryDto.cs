using Tashgheel_Api.Entities;

namespace Tashgheel_Api.DATA.DTOs
{

    public class CategoryDto : BaseDto<Guid>
    {
        public string?  Name { get; set; }
        public CategoryType? Type { get; set; }

    }
}
