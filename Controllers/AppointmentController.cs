using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tashgheel;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : BaseController
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Create([FromBody] AppointmentForm appointment)
    {
        return Ok(await _appointmentService.Create(appointment, Id));
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _appointmentService.GetAll());
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult> GetById(Guid id)
    {
        return Ok(await _appointmentService.GetById(id));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] AppointmentForm appointment, Guid id)
    {
        return Ok(await _appointmentService.Update(appointment, id));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _appointmentService.Delete(id));
    }

    [HttpGet("MyAppointments")]
    [Authorize]
    public async Task<ActionResult> GetAllMyAppointments()
    {
        return Ok(await _appointmentService.GetAllMyAppointments(Id));
    }

    [HttpPut("ChangeAppointmentStatus/{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateStatus(Guid id, AppointmentStatus status)
    {
        return Ok(await _appointmentService.UpdateStatus(id, status));
    }

 [HttpPost("SendEmail")]
 [Authorize]
 public async Task<ActionResult> SendEmail(Guid id, string subject, string message)
 {
     return Ok(await _appointmentService.SendEmail(id, subject, message));
 }
}