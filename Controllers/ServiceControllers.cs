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
    public class ServicesController : BaseController
    {
        private readonly IServiceServices _serviceServices;

        public ServicesController(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAll([FromQuery] ServiceFilter filter) => Ok(await _serviceServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<Service>> Create([FromBody] ServiceForm serviceForm) => Ok(await _serviceServices.Create(serviceForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Update([FromBody] ServiceUpdate serviceUpdate, Guid id) => Ok(await _serviceServices.Update(id , serviceUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(Guid id) =>  Ok( await _serviceServices.Delete(id));
        
    }
}
