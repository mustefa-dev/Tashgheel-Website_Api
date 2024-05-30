using System.ComponentModel.DataAnnotations.Schema;

namespace Tashgheel_Api.Entities;

public class Appointment : BaseEntity<Guid>
{
    public AppUser? User { get; set; }
    [ForeignKey(nameof(UserId))]
    public Guid? UserId { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }=AppointmentStatus.Pending;
    
    
}
public enum AppointmentStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2

}