using Tashgheel_Api.Helpers;
using Tashgheel_Api.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventsServices _eventsServices;

        public EventsController(IEventsServices eventsServices)
        {
            _eventsServices = eventsServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<EventsDto>>> GetAll([FromQuery] EventsFilter filter) => Ok(await _eventsServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Events>> Create([FromBody] EventsForm eventsForm) => Ok(await _eventsServices.Create(eventsForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Events>> Update([FromBody] EventsUpdate eventsUpdate, Guid id) => Ok(await _eventsServices.Update(id , eventsUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Events>> Delete(Guid id) =>  Ok( await _eventsServices.Delete(id));
        
        [HttpPost("register")]
        public async Task<ActionResult<EventRegistration>> Register([FromBody] EventRegistrationForm registrationForm) => Ok(await _eventsServices.Register(registrationForm,Id));
        [HttpPut]
        public async Task<ActionResult<EventRegistration>> ChangeStatus( EventRegistrationStatus status, Guid id) => Ok(await _eventsServices.ChangeStatus(id, status));
        [HttpPost("send-email")]
        public async Task<ActionResult<EventRegistration>> SendEmail([FromBody] EmailMessageForm emailMessageForm, Guid id) => Ok(await _eventsServices.SendEmail(id, emailMessageForm.Subject, emailMessageForm.Body));
        [HttpGet("my-registrations")]
        public async Task<ActionResult<List<EventRegistrationDto>> > GetMyRegistrations() => Ok(await _eventsServices.GetMyRegistrations(Id));
    }
}
