namespace Tashgheel_Api.DATA.DTOs
{

    public class AppSettingForm 
    {
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
}
