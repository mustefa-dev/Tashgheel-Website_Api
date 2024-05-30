using System.ComponentModel.DataAnnotations;

namespace Tashgheel_Api.DATA.DTOs;

public class BaseDto<TId>
{
    [Key] public TId Id { get; set; }

    public DateTime? CreationDate { get; set; } = DateTime.UtcNow;
}