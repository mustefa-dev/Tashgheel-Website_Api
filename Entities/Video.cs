namespace Tashgheel_Api.Entities;

public class Video : BaseEntity<Guid>
    
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
    public string? Thumbnail { get; set; }
    public int? Order { get; set; }
    public Guid? ChapterId { get; set; }
}