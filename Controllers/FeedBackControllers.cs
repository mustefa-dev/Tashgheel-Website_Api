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
    public class FeedBacksController : BaseController
    {
        private readonly IFeedBackServices _feedbackServices;

        public FeedBacksController(IFeedBackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<FeedBackDto>>> GetAll([FromQuery] FeedBackFilter filter) => Ok(await _feedbackServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

            
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetById(Guid id) => Ok(await _feedbackServices.GetById(id));
        
        [HttpPost]
        public async Task<ActionResult<FeedBack>> Create([FromBody] FeedBackForm feedbackForm) => Ok(await _feedbackServices.Create(feedbackForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<FeedBack>> Update([FromBody] FeedBackUpdate feedbackUpdate, Guid id) => Ok(await _feedbackServices.Update(id , feedbackUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeedBack>> Delete(Guid id) =>  Ok( await _feedbackServices.Delete(id));
        
    }
}
