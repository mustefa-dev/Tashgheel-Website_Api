using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;

public class AppSetting : BaseEntity<Guid>
{
    public AppSetting()
    {
        TashgeelCompanyMapLocation = new Location();
        Title = "";
        Description = "";
        BackgroundImage = "";
        SupportPhoneNumber = "";
        PrimaryEmail = "";
        FirstSecondaryEmail = "";
        SecondSecondaryEmail = "";
        TashgeelCompanyAddress = "";
        FacebookLink = "";
        LinkedinLink = "";
        TeleLink = "";
        InstagramLink = "";
        GooglePlayLink = "";
        AppStoreLink = "";
    }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? BackgroundImage { get; set; }
    public string? SupportPhoneNumber { get; set; }
    public string? PrimaryEmail { get; set; }
    public string? FirstSecondaryEmail { get; set; }
    public string? SecondSecondaryEmail { get; set; }
    public string? TashgeelCompanyAddress { get; set; }
    public Location TashgeelCompanyMapLocation { get; set; }
    public string? FacebookLink { get; set; }
    public string? LinkedinLink { get; set; }
    public string? TeleLink { get; set; }
    public string? InstagramLink { get; set; }
    public string? GooglePlayLink { get; set; }
    public string? AppStoreLink { get; set; }
}