using Tweetinvi.Core.Models;

namespace Tashgheel_Api.Entities;

public class Review : BaseEntity<Guid>
{
    public AppUser User { get; set; }
    public string? ReviewText{ get; set; }
    public float? Rating { get; set; }
    
    
}