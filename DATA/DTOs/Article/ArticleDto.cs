namespace Tashgheel_Api.DATA.DTOs
{

    public class ArticleDto : BaseDto<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? MainImage { get; set; }
        public List<string> Images {get; set;}
        


    }
}
