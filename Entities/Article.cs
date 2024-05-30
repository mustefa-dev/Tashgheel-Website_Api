using System.ComponentModel.DataAnnotations;

namespace Tashgheel_Api.Entities
{
    public class Article : BaseEntity<Guid>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required] 
        public string MainImage { get; set; }
        public List<string> Images { get; set; }
        [Required]
        public bool isMain { get; set; }
    }
}
