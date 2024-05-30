namespace Tashgheel_Api.Entities
{
    public class Service : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
