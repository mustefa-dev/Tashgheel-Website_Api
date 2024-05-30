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
    public class SlidingBarsController : BaseController
    {
        private readonly ISlidingBarServices _slidingbarServices;

        public SlidingBarsController(ISlidingBarServices slidingbarServices)
        {
            _slidingbarServices = slidingbarServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<SlidingBarDto>>> GetAll([FromQuery] SlidingBarFilter filter) => Ok(await _slidingbarServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<SlidingBar>> Create([FromBody] SlidingBarForm slidingbarForm) => Ok(await _slidingbarServices.Create(slidingbarForm));
        [HttpGet("{id}")]
        public async Task<ActionResult<SlidingBar>> GetById(Guid id) => Ok(await _slidingbarServices.GetById(id));
        
        [HttpPut("{id}")]
        public async Task<ActionResult<SlidingBar>> Update([FromBody] SlidingBarUpdate slidingbarUpdate, Guid id) => Ok(await _slidingbarServices.Update(id , slidingbarUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<SlidingBar>> Delete(Guid id) =>  Ok( await _slidingbarServices.Delete(id));
        
    }
}
