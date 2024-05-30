using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;


public class AppointmentDto : BaseDto<Guid>
{
    public Guid? UserId { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
}