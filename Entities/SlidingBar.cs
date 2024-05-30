namespace Tashgheel_Api.Entities
{
    public class SlidingBar : BaseEntity<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? BackgroundColor { get; set; }
        public string? StartButtonLink { get; set; }
        public string? LearnMoreButtonLink { get; set; }
        public PriorityIndex? Priority { get; set; }
        
    }
}
public enum PriorityIndex
{
    First,
    Second,
    Third,
    Fourth,
    Fifth
}
    