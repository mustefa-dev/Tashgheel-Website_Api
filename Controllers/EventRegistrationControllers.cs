// using Tashgheel_Api.Helpers;
// using Tashgheel_Api.Properties;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Tashgheel_Api.DATA.DTOs;
// using Tashgheel_Api.Entities;
// using Tashgheel_Api.Services;
//
// namespace Tashgheel_Api.Controllers
// {
//     public class EventRegistrationsController : BaseController
//     {
//         private readonly IEventRegistrationServices _eventregistrationServices;
//
//         public EventRegistrationsController(IEventRegistrationServices eventregistrationServices)
//         {
//             _eventregistrationServices = eventregistrationServices;
//         }
//
//         
//         [HttpGet]
//         public async Task<ActionResult<List<EventRegistrationDto>>> GetAll([FromQuery] EventRegistrationFilter filter) => Ok(await _eventregistrationServices.GetAll(filter) , filter.PageNumber , filter.PageSize);
//
//         
//         [HttpPost]
//         public async Task<ActionResult<EventRegistration>> Create([FromBody] EventRegistrationForm eventregistrationForm) => Ok(await _eventregistrationServices.Create(eventregistrationForm));
//
//         
//         [HttpPut("{id}")]
//         public async Task<ActionResult<EventRegistration>> Update([FromBody] EventRegistrationUpdate eventregistrationUpdate, Guid id) => Ok(await _eventregistrationServices.Update(id , eventregistrationUpdate));
//
//         
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<EventRegistration>> Delete(Guid id) =>  Ok( await _eventregistrationServices.Delete(id));
//         
//     }
// }
