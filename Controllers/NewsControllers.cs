
using Microsoft.AspNetCore.Mvc;
using Tashgheel_Api.DATA.DTOs;
using Tashgheel_Api.Entities;
using Tashgheel_Api.Services;

namespace Tashgheel_Api.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsServices _newsServices;

        public NewsController(INewsServices newsServices)
        {
            _newsServices = newsServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<NewsDto>>> GetAll([FromQuery] NewsFilter filter) => Ok(await _newsServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<News>> Create([FromBody] NewsForm newsForm) => Ok(await _newsServices.Create(newsForm));
        
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetById(Guid id) => Ok(await _newsServices.GetById(id));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<News>> Update([FromBody] NewsUpdate newsUpdate, Guid id) => Ok(await _newsServices.Update(id , newsUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> Delete(Guid id) =>  Ok( await _newsServices.Delete(id));
        
    }
}
