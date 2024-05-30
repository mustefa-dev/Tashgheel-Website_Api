namespace Tashgheel_Api.DATA.DTOs
{

    public class ServiceDto: BaseDto<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
       
    }
}
