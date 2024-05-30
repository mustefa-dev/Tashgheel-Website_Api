using Tashgheel_Api.Entities;


public class LinkedInProfile: BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
}